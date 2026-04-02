using PointFlow.Model;

// ── Tags ─────────────────────────────────────────────────────────────────────
var tagStudy    = new Tag { Id = 1, Name = "Study" };
var tagWork     = new Tag { Id = 2, Name = "Work" };
var tagHealth   = new Tag { Id = 3, Name = "Health" };
var tagPersonal = new Tag { Id = 4, Name = "Personal" };

// ── Categories ───────────────────────────────────────────────────────────────
var categoryLearning = new Category
{
    Id = 1,
    Name = "Learning",
    Description = "Tasks related to acquiring new knowledge"
};

var categoryFitness = new Category
{
    Id = 2,
    Name = "Fitness",
    Description = "Tasks related to physical health and exercise"
};

var categoryWork = new Category
{
    Id = 3,
    Name = "Work",
    Description = "Professional and career-related tasks"
};

// ── AppUser 1 — Ana ──────────────────────────────────────────────────────────
var ana = new AppUser
{
    Id = 1,
    Username = "ana_k",
    Email = "ana@example.com",
    TotalPointsEarned = 320,
    CurrentBalance = 150,
    CreatedAt = new DateTime(2025, 9, 1)
};

var quiz1 = new Quiz
{
    Id = 1,
    Question = "What is the difference between a class and a struct in C#?",
    ExpectedAnswer = "A class is a reference type allocated on the heap; a struct is a value type allocated on the stack.",
    UserAnswer = "Classes are reference types, structs are value types stored on the stack.",
    PomodoroSessionId = 1
};

var session1 = new PomodoroSession
{
    Id = 1,
    StartTime = new DateTime(2026, 3, 1, 9, 0, 0),
    EndTime   = new DateTime(2026, 3, 1, 9, 25, 0),
    DurationMinutes = 25,
    LearnedNotes = "Covered C# type system: value types vs reference types, boxing/unboxing.",
    IsQuizPassed = true,
    PointTaskId = 1,
    Quizzes = [quiz1]
};
quiz1.PomodoroSession = session1;

var anaTask1 = new PointTask
{
    Id = 1,
    Title = "Study C# fundamentals",
    Description = "Go through chapters 1-5 of the C# guide",
    PointsReward = 50,
    IsCompleted = true,
    Priority = TaskPriority.High,
    CreatedAt = new DateTime(2026, 3, 1),
    AppUserId = ana.Id,
    AppUser = ana,
    CategoryId = categoryLearning.Id,
    Category = categoryLearning,
    Tags = [tagStudy],
    PomodoroSessions = [session1]
};
session1.PointTask = anaTask1;
categoryLearning.Tasks.Add(anaTask1);

var anaTask2 = new PointTask
{
    Id = 2,
    Title = "Run 5km",
    Description = "Morning run in the park",
    PointsReward = 30,
    IsCompleted = true,
    Priority = TaskPriority.Medium,
    CreatedAt = new DateTime(2026, 3, 3),
    AppUserId = ana.Id,
    AppUser = ana,
    CategoryId = categoryFitness.Id,
    Category = categoryFitness,
    Tags = [tagHealth]
};
categoryFitness.Tasks.Add(anaTask2);

var anaTask3 = new PointTask
{
    Id = 3,
    Title = "Read Clean Code book",
    Description = "At least 30 pages per session",
    PointsReward = 40,
    IsCompleted = false,
    Priority = TaskPriority.Low,
    CreatedAt = new DateTime(2026, 3, 10),
    AppUserId = ana.Id,
    AppUser = ana,
    CategoryId = categoryLearning.Id,
    Category = categoryLearning,
    Tags = [tagStudy, tagPersonal]
};
categoryLearning.Tasks.Add(anaTask3);

var anaReward1 = new Reward
{
    Id = 1,
    Name = "Netflix evening",
    Description = "1 hour of guilt-free Netflix",
    PointsCost = 50,
    IsLocked = false,
    UnlockedAt = new DateTime(2026, 3, 5),
    AppUserId = ana.Id,
    AppUser = ana
};

var anaReward2 = new Reward
{
    Id = 2,
    Name = "Buy a new book",
    Description = "Treat yourself to a new technical book",
    PointsCost = 120,
    IsLocked = true,
    AppUserId = ana.Id,
    AppUser = ana
};

ana.Tasks    = [anaTask1, anaTask2, anaTask3];
ana.Rewards  = [anaReward1, anaReward2];
tagStudy.Tasks.AddRange([anaTask1, anaTask3]);
tagHealth.Tasks.Add(anaTask2);
tagPersonal.Tasks.Add(anaTask3);

// ── AppUser 2 — Marko ────────────────────────────────────────────────────────
var marko = new AppUser
{
    Id = 2,
    Username = "marko_p",
    Email = "marko@example.com",
    TotalPointsEarned = 200,
    CurrentBalance = 80,
    CreatedAt = new DateTime(2025, 11, 15)
};

var markoTask1 = new PointTask
{
    Id = 4,
    Title = "Finish quarterly report",
    Description = "Compile Q1 data and write summary",
    PointsReward = 60,
    IsCompleted = false,
    Priority = TaskPriority.High,
    CreatedAt = new DateTime(2026, 3, 20),
    AppUserId = marko.Id,
    AppUser = marko,
    CategoryId = categoryWork.Id,
    Category = categoryWork,
    Tags = [tagWork]
};
categoryWork.Tasks.Add(markoTask1);

var markoTask2 = new PointTask
{
    Id = 5,
    Title = "Gym session",
    Description = "Upper body workout",
    PointsReward = 25,
    IsCompleted = true,
    Priority = TaskPriority.Medium,
    CreatedAt = new DateTime(2026, 3, 22),
    AppUserId = marko.Id,
    AppUser = marko,
    CategoryId = categoryFitness.Id,
    Category = categoryFitness,
    Tags = [tagHealth, tagPersonal]
};
categoryFitness.Tasks.Add(markoTask2);

var markoTask3 = new PointTask
{
    Id = 6,
    Title = "Learn LINQ",
    Description = "Practice LINQ queries with real datasets",
    PointsReward = 45,
    IsCompleted = false,
    Priority = TaskPriority.High,
    CreatedAt = new DateTime(2026, 3, 25),
    AppUserId = marko.Id,
    AppUser = marko,
    CategoryId = categoryLearning.Id,
    Category = categoryLearning,
    Tags = [tagStudy, tagWork]
};
categoryLearning.Tasks.Add(markoTask3);

var markoReward1 = new Reward
{
    Id = 3,
    Name = "Gaming session",
    Description = "2 hours of gaming without guilt",
    PointsCost = 60,
    IsLocked = false,
    UnlockedAt = new DateTime(2026, 3, 23),
    AppUserId = marko.Id,
    AppUser = marko
};

var markoReward2 = new Reward
{
    Id = 4,
    Name = "Weekend trip",
    Description = "Short trip to the mountains",
    PointsCost = 300,
    IsLocked = true,
    AppUserId = marko.Id,
    AppUser = marko
};

marko.Tasks   = [markoTask1, markoTask2, markoTask3];
marko.Rewards = [markoReward1, markoReward2];
tagWork.Tasks.AddRange([markoTask1, markoTask3]);
tagHealth.Tasks.Add(markoTask2);
tagPersonal.Tasks.Add(markoTask2);
tagStudy.Tasks.Add(markoTask3);

// ── AppUser 3 — Petra ────────────────────────────────────────────────────────
var petra = new AppUser
{
    Id = 3,
    Username = "petra_v",
    Email = "petra@example.com",
    TotalPointsEarned = 510,
    CurrentBalance = 260,
    CreatedAt = new DateTime(2025, 6, 1)
};

var quiz2 = new Quiz
{
    Id = 2,
    Question = "What does SOLID stand for?",
    ExpectedAnswer = "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion.",
    UserAnswer = "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion.",
    PomodoroSessionId = 2
};

var session2 = new PomodoroSession
{
    Id = 2,
    StartTime = new DateTime(2026, 3, 15, 10, 0, 0),
    EndTime   = new DateTime(2026, 3, 15, 10, 25, 0),
    DurationMinutes = 25,
    LearnedNotes = "Studied SOLID principles with examples in C#.",
    IsQuizPassed = true,
    PointTaskId = 7,
    Quizzes = [quiz2]
};
quiz2.PomodoroSession = session2;

var petraTask1 = new PointTask
{
    Id = 7,
    Title = "Study SOLID principles",
    Description = "Deep dive into object-oriented design principles",
    PointsReward = 70,
    IsCompleted = true,
    Priority = TaskPriority.High,
    CreatedAt = new DateTime(2026, 3, 15),
    AppUserId = petra.Id,
    AppUser = petra,
    CategoryId = categoryLearning.Id,
    Category = categoryLearning,
    Tags = [tagStudy],
    PomodoroSessions = [session2]
};
session2.PointTask = petraTask1;
categoryLearning.Tasks.Add(petraTask1);

var petraTask2 = new PointTask
{
    Id = 8,
    Title = "Prepare presentation",
    Description = "Slides for the team meeting on architecture",
    PointsReward = 50,
    IsCompleted = true,
    Priority = TaskPriority.High,
    CreatedAt = new DateTime(2026, 3, 18),
    AppUserId = petra.Id,
    AppUser = petra,
    CategoryId = categoryWork.Id,
    Category = categoryWork,
    Tags = [tagWork, tagStudy]
};
categoryWork.Tasks.Add(petraTask2);

var petraTask3 = new PointTask
{
    Id = 9,
    Title = "Yoga session",
    Description = "30 min morning yoga",
    PointsReward = 20,
    IsCompleted = true,
    Priority = TaskPriority.Low,
    CreatedAt = new DateTime(2026, 3, 26),
    AppUserId = petra.Id,
    AppUser = petra,
    CategoryId = categoryFitness.Id,
    Category = categoryFitness,
    Tags = [tagHealth, tagPersonal]
};
categoryFitness.Tasks.Add(petraTask3);

var petraReward1 = new Reward
{
    Id = 5,
    Name = "Spa day",
    Description = "Full relaxation day at the spa",
    PointsCost = 200,
    IsLocked = false,
    UnlockedAt = new DateTime(2026, 3, 20),
    AppUserId = petra.Id,
    AppUser = petra
};

var petraReward2 = new Reward
{
    Id = 6,
    Name = "Online course",
    Description = "Enroll in an advanced .NET course",
    PointsCost = 150,
    IsLocked = false,
    UnlockedAt = new DateTime(2026, 3, 27),
    AppUserId = petra.Id,
    AppUser = petra
};

petra.Tasks   = [petraTask1, petraTask2, petraTask3];
petra.Rewards = [petraReward1, petraReward2];
tagStudy.Tasks.AddRange([petraTask1, petraTask2]);
tagWork.Tasks.Add(petraTask2);
tagHealth.Tasks.Add(petraTask3);
tagPersonal.Tasks.Add(petraTask3);

// ── Ispis ─────────────────────────────────────────────────────────────────────
var users = new List<AppUser> { ana, marko, petra };

foreach (var user in users)
{
    //Console.WriteLine($"{"═",0}{"",50}".Replace(" ", "═"));
    Console.WriteLine(new string('═', 50));
    Console.WriteLine($"  USER: {user.Username} | Balance: {user.CurrentBalance} pts | Total earned: {user.TotalPointsEarned} pts");
    Console.WriteLine(new string('─', 50));

    Console.WriteLine("  TASKS:");
    foreach (var task in user.Tasks)
    {
        var status   = task.IsCompleted ? "✓" : "○";
        var tags     = task.Tags.Count > 0 ? string.Join(", ", task.Tags.Select(t => t.Name)) : "—";
        Console.WriteLine($"    [{status}] [{task.Priority}] {task.Title} (+{task.PointsReward} pts)");
        Console.WriteLine($"         Category: {task.Category.Name} | Tags: {tags}");

        foreach (var session in task.PomodoroSessions)
        {
            var notes = session.LearnedNotes.Length > 50 ? session.LearnedNotes[..50] + "..." : session.LearnedNotes;
            Console.WriteLine($"         🍅 Pomodoro #{session.Id} ({session.DurationMinutes} min) — Notes: {notes}");
            foreach (var quiz in session.Quizzes)
            {
                var passed = session.IsQuizPassed ? "PASSED" : "FAILED";
                var question = quiz.Question.Length > 50 ? quiz.Question[..50] + "..." : quiz.Question;
                Console.WriteLine($"            Quiz [{passed}]: {question}");
            }
        }
    }

    Console.WriteLine("  REWARDS:");
    foreach (var reward in user.Rewards)
    {
        var locked = reward.IsLocked ? "🔒 Locked" : "🔓 Unlocked";
        Console.WriteLine($"    {locked} — {reward.Name} ({reward.PointsCost} pts)");
    }

    Console.WriteLine();
}

// ── LINQ upiti ────────────────────────────────────────────────────────────────
var allTasks = users.SelectMany(u => u.Tasks).ToList();

Console.WriteLine(new string('═', 50));
Console.WriteLine("  LINQ: Taskovi s High prioritetom");
Console.WriteLine(new string('─', 50));
var highPriorityTasks = allTasks
    .Where(t => t.Priority == TaskPriority.High)
    .OrderBy(t => t.AppUser.Username);
foreach (var task in highPriorityTasks)
    Console.WriteLine($"  [{(task.IsCompleted ? "✓" : "○")}] {task.AppUser.Username} — {task.Title}");

Console.WriteLine();
Console.WriteLine(new string('═', 50));
Console.WriteLine("  LINQ: Korisnici s više od 100 bodova");
Console.WriteLine(new string('─', 50));
var richUsers = users
    .Where(u => u.CurrentBalance > 100)
    .OrderByDescending(u => u.CurrentBalance);
foreach (var user in richUsers)
    Console.WriteLine($"  {user.Username} — {user.CurrentBalance} pts");

Console.WriteLine();
Console.WriteLine(new string('═', 50));
Console.WriteLine("  LINQ: Taskovi s tagom 'Study'");
Console.WriteLine(new string('─', 50));
var studyTasks = allTasks
    .Where(t => t.Tags.Any(tag => tag.Name == "Study"))
    .OrderBy(t => t.AppUser.Username);
foreach (var task in studyTasks)
    Console.WriteLine($"  {task.AppUser.Username} — {task.Title}");

Console.WriteLine();

await SimulirajSpremanjeAsync();

static async Task SimulirajSpremanjeAsync()
{
    Console.WriteLine(new string('═', 50));
    Console.WriteLine("  Spremanje podataka...");
    await Task.Delay(1000);
    Console.WriteLine("  Spremanje završeno.");
    Console.WriteLine(new string('═', 50));
}

