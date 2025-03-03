namespace WebApplicationCourseWork.Authentication{
public class AuthModel
{
    
     public string Email { get; set; }
    public string Password { get; set; }
    //public string ConfirmedPass {get; set;} // the idea with this was that i would implement a feature for it to confirm the password before moving onto the loginmodel.
}
}