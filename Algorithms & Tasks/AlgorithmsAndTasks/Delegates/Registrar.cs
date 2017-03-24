namespace Delegates
{
    class Registrar
    {
        public static void Log(double gpa)
        {

        }

        void Run()
        {
            Student ann = new Student("Ann");

            ann.GpaChanged = new StudentCallback(Registrar.Log);
        }
    }
}