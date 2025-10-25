namespace Task3;

public class UserModel
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public int Age { get; set; }

    public int Salary { get; set; }

    public string Department { get; set; }

    public UserModel(string firstName, string lastName, string email, int age, int salary, string department)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Age = age;
        Salary = salary;
        Department = department;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var secondObject = (UserModel)obj;
        return (secondObject.FirstName == FirstName && secondObject.LastName == LastName && secondObject.Email == Email 
            && secondObject.Age == Age && secondObject.Salary == Salary && secondObject.Department == Department);
    }
}
