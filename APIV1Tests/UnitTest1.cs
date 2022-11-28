namespace APIV1Tests;

public class EmployeeControllerTest
{
    [Fact]
    public void WriteEmployeeCSV_WithEmployeeToWrite_ReturnsCreatedEmployee()
    {
        //Arrange
        var employee =  new Employee(){
            Firstname = "Jack",
            Lastname = "Pervins",
            Email = "email@gmail.com",
            Phone= "0756425896",
            TimeInterval = "none",
            LinkedinURL = "none",
            GithubURL = "none"
        };

        
        var controller = new EmployeeController(ICSVService);
        //Act
        var result = controller.WriteEmployeeCSV(employee);
        //Assert
        var createdEmployee =  (result.Result as CreatedAtActionResult).Value as Employee;
        employee.Should().BeEquivalentTo(
            createdEmployee,
            options => options.ComparingByMembers<Employee>()
        );

    }
}