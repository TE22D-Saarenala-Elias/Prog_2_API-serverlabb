
//  Mickes --> 10.151.172.158:5025

var builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

List <Teacher> teachers =[
    new() {Name = "Micke 1"},
    new() {Name = "Micke 2"},
    new() {Name = "Micke 3"},
    new() {Name = "Micke 4"},
    new() {Name = "Micke 5"},
];

app.Urls.Add("http://localhost:5241/");
app.Urls.Add("http://*:5241/");


app.MapGet("/", GetHello);
app.MapGet("/Teacher", GetTeachers);
app.MapGet("/Teacher/{n}",GetTeacher);
app.MapPost("/PutTeacher", PutTeacher);

app.Run();

static string PutTeacher(Teacher t)
{
    Console.WriteLine("Got new teacher " + t.Name);

    return "Yes";
}



List <Teacher> GetTeachers(){
    return teachers;
}

IResult GetTeacher(int n)
{
     if(n<0 || n>=teachers.Count()) { 
        return Results.NotFound();
     }
     return Results.Ok (teachers[n]);  
}


static string GetHello()
{
    return "Hello";
}

//          5241