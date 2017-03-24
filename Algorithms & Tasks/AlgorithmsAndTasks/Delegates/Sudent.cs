namespace Delegates
{
    class Student
    {
        public StudentCallback GpaChanged;

        string name;
        double gpa;
        int units;

        public Student(string name)
        {
            this.name = name;
        }

        public void ChangeGpa(int grade)
        {
            gpa = (gpa * units + grade) / (units + 1);
            units++;

            if (GpaChanged != null)
            {
                GpaChanged(gpa);
            }
        }
    }
}