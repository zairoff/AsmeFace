namespace AsmeFace
{
    public class Employee
    {
        public Employee()
        {

        }

        public Employee(int iD, byte[] photo, string ism, string familiya, string otchestvo, string otdel, string lavozim, string address, string enrollment_number, string amizone_code)
        {
            ID = iD;
            Photo = photo;
            Ism = ism;
            Familiya = familiya;
            Otchestvo = otchestvo;
            Otdel = otdel;
            Lavozim = lavozim;
            Address = address;
        }

        public int ID { get; set; }

        public byte[] Photo { get; set; }

        public byte[] Finger { get; set; }

        public string Card { get; set; }

        public string Ism { get; set; }

        public string Familiya { get; set; }

        public string Otchestvo { get; set; }

        public string Otdel { get; set; }

        public string Lavozim { get; set; }

        public string Address { get; set; }
    }
}
