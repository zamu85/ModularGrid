using System.Collections.ObjectModel;
using Commonality.Dto.File;
using Commonality.Dto.Messages;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Services.File;

namespace View.ViewModel.File
{
    public class FileViewModel
    {
        private readonly FileService _fileService;

        public FileViewModel(FileService fileService)
        {
            _fileService = fileService;
            Messenger.Default.Register<ExamMessage>(this, onExamSelected);
        }

        public ObservableCollection<FileDto> Files { get; } = new ObservableCollection<FileDto>();

        private void onExamSelected(ExamMessage message)
        {
            Files.Clear();
            _fileService.GetFilesByExamId(message.ExamId).ForEach(Files.Add);
        }
    }
}
