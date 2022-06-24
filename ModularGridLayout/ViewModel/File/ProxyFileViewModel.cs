using System.Collections.Generic;
using Commonality.Dto.File;
using Services.File;

namespace View.ViewModel.File
{
    public class ProxyFileViewModel : IProxyFileViewModel
    {
        private readonly FileService _fileService;
        private IDictionary<int, IEnumerable<FileDto>> _filesForExam;
        private FileViewModel _fileViewModel;

        public ProxyFileViewModel(FileService fileService)
        {
            _fileService = fileService;
            _fileViewModel = new(fileService);
            _filesForExam = new Dictionary<int, IEnumerable<FileDto>>();
        }

        public IEnumerable<FileDto> GetAll(int examId)
        {
            if (_filesForExam.ContainsKey(examId))
            {
                return _filesForExam[examId];
            }

            var result = _fileViewModel.GetAll(examId);

            _filesForExam.Add(examId, result);

            return result;
        }
    }
}
