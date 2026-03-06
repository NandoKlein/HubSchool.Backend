namespace HubSchool.Data.Dto
{
    public class AlunoDTO
    {

        public long Id { get; set; }
        public long Matricula { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Address { get; set; }   
        public DateTime? Birthday { get; set; }               
        public string Email { get; set; }        
        public string Phone { get; set; }
        public DateTime? DataDaMatricula { get; set; }
    }
}
