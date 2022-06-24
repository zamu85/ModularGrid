using System.Collections.Generic;
using Commonality.Dto.File;

namespace View.ViewModel.File
{
    public interface IProxyFileViewModel
    {
        IEnumerable<FileDto> GetAll(int examId);
    }
}
