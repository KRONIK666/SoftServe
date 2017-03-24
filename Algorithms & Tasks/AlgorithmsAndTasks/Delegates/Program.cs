namespace Delegates
{
    class Program
    {
        static void Main()
        {
            Parent dad = new Parent();
            Parent mom = new Parent();
            Student ann = new Student("Ann");

            ann.GpaChanged = new StudentCallback(mom.Report);
            ann.ChangeGpa(4);

            ann.GpaChanged += new StudentCallback(dad.Report);
            ann.GpaChanged += new StudentCallback(mom.Report);
            ann.GpaChanged -= new StudentCallback(dad.Report);
        }
    }
}