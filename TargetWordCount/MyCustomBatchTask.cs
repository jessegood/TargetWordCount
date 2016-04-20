using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.ProjectAutomation.AutomaticTasks;
using Sdl.ProjectAutomation.Core;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TargetWordCount
{
    [AutomaticTask("TargetWordCountID",
        "Target Word Count",
        "Counts number of words in target",
        //[TODO] You can change the file type according to your needs
        GeneratedFileType = AutomaticTaskFileType.BilingualTarget)]
    //[TODO] You can change the file type according to your needs
    [AutomaticTaskSupportedFileType(AutomaticTaskFileType.BilingualTarget)]
    [RequiresSettings(typeof(MyCustomBatchTaskSettings), typeof(MyCustomBatchTaskSettingsPage))]
    public class MyCustomBatchTask : AbstractFileContentProcessingAutomaticTask
    {
        private readonly Dictionary<string, int> files = new Dictionary<string, int>();
        private readonly SegmentWordCounter wordCounter = new SegmentWordCounter();

        protected override void ConfigureConverter(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            wordCounter.Words = 0;
            wordCounter.WordCounter = GetWordCounter(projectFile);
            multiFileConverter.AddBilingualProcessor(wordCounter);
        }

        public override bool OnFileComplete(ProjectFile projectFile, IMultiFileConverter multiFileConverter)
        {
            files.Add(projectFile.Name, wordCounter.Words);
            return false;
        }

        public override void TaskComplete()
        {
            XElement root = new XElement("Report");

            foreach (var file in files)
            {
                root.Add(new XElement("File", file.Key, new XAttribute("Count", file.Value)));
            }

            CreateReport("Target Word Count", "Word count for each file", root.ToString());
        }
    }
}