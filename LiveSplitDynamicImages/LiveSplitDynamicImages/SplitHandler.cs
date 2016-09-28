using LiveSplit.Model;
using LiveSplit.Model.Comparisons;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiveSplitDynamicImages
{
    class SplitHandler
    {
        private LiveSplitState state;
        private SplitColour lastSplitColour;
        private ObsPipe pipe;
        private Settings settings;

        public SplitHandler(LiveSplitState state, Settings settings, ObsPipe pipe)
        {
            this.state = state;
            this.settings = settings;
            this.pipe = pipe;
            subscribeToSplitEvents(this.state);
        }

        ~SplitHandler()
        {
            unsubscribeToSplitEvents(state);
        }

        private void unsubscribeToSplitEvents(LiveSplitState state)
        {
            state.OnStart -= OnStart;
            state.OnSplit -= OnSplit;
            state.OnUndoSplit -= OnUndoSplit;
            state.OnSkipSplit -= OnSkipSplit;
            state.OnReset -= OnReset;
        }

        private void subscribeToSplitEvents(LiveSplitState state)
        {
            state.OnStart += OnStart;
            state.OnSplit += OnSplit;
            state.OnUndoSplit += OnUndoSplit;
            state.OnSkipSplit += OnSkipSplit;
            state.OnReset += OnReset;
        }

        private void OnStart(object sender, EventArgs e)
        {
            lastSplitColour = SplitColour.NONE;
            updateSplitImage(settings.newRunImage);
        }

        private void OnSplit(object sender, EventArgs e)
        {
            if (state.CurrentPhase == TimerPhase.Ended)
            {
                String splitImage;
                if (state.Run.Last().PersonalBestSplitTime[state.CurrentTimingMethod] == null || state.Run.Last().SplitTime[state.CurrentTimingMethod] < state.Run.Last().PersonalBestSplitTime[state.CurrentTimingMethod])
                {
                    if (settings.runEndPBImage != null)
                        splitImage = settings.runEndPBImage;
                    else
                        splitImage = settings.getImagePathFromColour(SplitColour.GOLD, lastSplitColour);
                }
                else
                {
                    if (settings.runEndNoPBImage != null)
                        splitImage = settings.runEndNoPBImage;
                    else
                        splitImage = settings.getImagePathFromColour(SplitColour.DARK_RED, lastSplitColour);
                }
                updateSplitImage(splitImage);
            }
            else
            {
                SplitColour splitColour = calculateSplitColour();
                updateSplitImage(splitColour);
                lastSplitColour = splitColour;
            }
            
        }

        private SplitColour calculateSplitColour()
        {
            if (isGoldSplit())
                return SplitColour.GOLD;
            return calculateNonGoldSplitColour();
        }

        private bool isGoldSplit()
        {
            int splitIndex = state.CurrentSplitIndex - 1;
            TimeSpan? curSegment = LiveSplitStateHelper.GetPreviousSegmentTime(state, splitIndex, state.CurrentTimingMethod);
            return state.Run[splitIndex].BestSegmentTime[state.CurrentTimingMethod] == null || curSegment < state.Run[splitIndex].BestSegmentTime[state.CurrentTimingMethod];
        }

        private SplitColour calculateNonGoldSplitColour()
        {
            int splitIndex = state.CurrentSplitIndex - 1;
            TimeSpan? splitTime = state.Run[splitIndex].SplitTime[state.CurrentTimingMethod];
            TimeSpan? comparisonSplitTime = state.Run[splitIndex].Comparisons[state.CurrentComparison][state.CurrentTimingMethod];
            TimeSpan? totalRunDifference = splitTime - comparisonSplitTime;

            TimeSpan? previousSegmentDifference = LiveSplitStateHelper.GetPreviousSegmentDelta(state, splitIndex, state.CurrentComparison, state.CurrentTimingMethod);

            if (totalRunDifference < TimeSpan.Zero)
            {
                if (previousSegmentDifference < TimeSpan.Zero)
                    return SplitColour.DARK_GREEN;
                return SplitColour.LIGHT_GREEN;
            }

            if (previousSegmentDifference < TimeSpan.Zero)
                return SplitColour.LIGHT_RED;
            return SplitColour.DARK_RED;
        }

        private void OnUndoSplit(object sender, EventArgs e)
        {

        }

        private void OnSkipSplit(object sender, EventArgs e)
        {

        }

        private void OnReset(object sender, TimerPhase value)
        {
            updateSplitImage(settings.resetImage);
        }

        private void updateSplitImage(SplitColour colour)
        {
            string path = settings.getImagePathFromColour(colour, lastSplitColour);
            updateSplitImage(path);
        }

        private void updateSplitImage(string imagePath)
        {
            pipe.changeImageFile(imagePath);
        }
    }
}
