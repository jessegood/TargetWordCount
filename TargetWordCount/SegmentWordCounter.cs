using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.ProjectAutomation.AutomaticTasks;

namespace TargetWordCount
{
    public class SegmentWordCounter : AbstractBilingualContentProcessor
    {
        public WordCounter WordCounter { get; set; }

        public int Words { get; set; }

        public override void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            if (paragraphUnit.IsStructure) { return; }

            foreach (var pair in paragraphUnit.SegmentPairs)
            {
                var target = pair.Target;

                Words += WordCounter.Count(target).Words;
            }
        }
    }
}