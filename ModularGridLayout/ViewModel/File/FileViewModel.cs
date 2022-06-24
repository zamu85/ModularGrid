using System.Collections.Generic;
using Commonality.Dto.File;
using Services.File;

namespace View.ViewModel.File
{
    public class FileViewModel : IProxyFileViewModel
    {
        private readonly FileService _fileService;

        public FileViewModel(FileService fileService)
        {
            _fileService = fileService;
            // Messenger.Default.Register<ExamMessage>(this, onExamSelected);
        }

        // public ObservableCollection<FileDto> Files { get; } = new ObservableCollection<FileDto>();

        public IEnumerable<FileDto> GetAll(int examId)
        {
            return _fileService.GetFilesByExamId(examId);
        }

        //private void onExamSelected(ExamMessage message)
        //{
        //    Files.Clear();
        //    _fileService.GetFilesByExamId(message.ExamId).ForEach(Files.Add);
        //}
    }
}
