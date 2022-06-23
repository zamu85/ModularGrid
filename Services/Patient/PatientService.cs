using Commonality.Dto.Patient;
using Model;

namespace Services.Patient
{
    public class PatientService
    {
        private IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Add(PatientDto patientDto)
        {
            Model.Patient.Patient patient = new(patientDto.BirthDate, patientDto.FirstName, patientDto.LastName);

            Model.Exam.Exam exam = new Model.Exam.Exam()
            {
                Code = "123",
                Comment = "test",
                RecordingDate = DateTime.Now,
            };

            Model.File.File file = new Model.File.File()
            {
                Comment = "test file",
                ExamType = 1,
                RecordingTime = DateTime.Now,
            };

            exam.AddFile(file);

            patient.AddExam(exam);

            _unitOfWork.PatientRepository.Add(patient);

            _unitOfWork.Save();
        }

        public IEnumerable<PatientDto> GetAllPatient()
        {
            return _unitOfWork.PatientRepository.GetAll().Select(x => new PatientDto()
            {
                BirthDate = x.BirthDate,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PatientId = x.PatientId,
            });
        }
    }
}
