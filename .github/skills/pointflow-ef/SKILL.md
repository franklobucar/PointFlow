---
name: pointflow-ef
description: 'Entity Framework Core skill za PointFlow projekt. Koristi kada: dodaješ novi model ili entitet, mijenjаš DbContext, kreiraš ili primjenjuješ migracije, uređuješ seed podatke, radiš s connection stringom, pišeš LINQ upite s Include/ThenInclude, debugiraš EF greške (FK violations, missing Include, cascade delete). Ključne riječi: migration, DbContext, PointFlowDbContext, seed data, Include, FK, AppUser, PointTask, Category, Tag, PomodoroSession, Quiz, Reward.'
argument-hint: 'Što trebaš: novi model / migracija / seed / query / connection string / greška'
---

# PointFlow — Entity Framework Core Skill

## Kada koristiti ovaj skill

- Dodavanje novog entiteta u model ili promjena postojećeg
- Kreiranje, uređivanje ili primjena EF migracija
- Rad s `PointFlowDbContext` (DbSet, relacije, `OnModelCreating`)
- Pisanje ili ispravljanje seed podataka (`HasData`)
- Pisanje LINQ upita s `Include`
- Connection string problemi
- Debugiranje EF grešaka (FK violations, missing Include)

---

## Infrastruktura projekta

| Komponenta | Detalj |
|---|---|
| ORM | Entity Framework Core 10.0.0 |
| Baza | SQL Server 2022 (Docker: `sqlserver-pointflow` na portu 1433) |
| Connection string | `appsettings.json` → `ConnectionStrings.DefaultConnection` |
| DbContext | `PointFlow.Model.PointFlowDbContext` |
| Migracije | `PointFlow.Model/Migrations/` |

### Docker kontejner (ako nije aktivan)
```bash
docker start sqlserver-pointflow
```

---

## DbContext — PointFlowDbContext

**Datoteka:** `PointFlow.Model/PointFlowDbContext.cs`

### DbSet-ovi
```csharp
DbSet<AppUser>         // Users
DbSet<Category>        // Categories
DbSet<PointTask>       // Tasks
DbSet<Tag>             // Tags
DbSet<PomodoroSession> // PomodoroSessions
DbSet<Quiz>            // Quizzes
DbSet<Reward>          // Rewards
```

### N:M relacija: PointTask ↔ Tag
```csharp
modelBuilder.Entity<PointTask>()
    .HasMany(pt => pt.Tags)
    .WithMany(t => t.Tasks)
    .UsingEntity<Dictionary<string, object>>("PointTaskTags");
```

Seed: `.HasData(new { TagsId = 1, TasksId = 1 }, ...)`

---

## Modeli

Svi entiteti imaju:
- `[Key]` na `Id`
- `[Required]` na obavezna polja
- `[MaxLength(n)]` na stringove
- `virtual ICollection<T>` za navigation propertije

Detalji: [semantic-model.md](../../../semantic-model.md)

### Relacije (sve s Cascade delete)
| FK | Vezano na |
|---|---|
| `PointTask.AppUserId` | `AppUser` |
| `PointTask.CategoryId` | `Category` |
| `PomodoroSession.PointTaskId` | `PointTask` |
| `Quiz.PomodoroSessionId` | `PomodoroSession` |
| `Reward.AppUserId` | `AppUser` |

---

## Migracije

### Postojeće (sve primijenjene)
| Migracija | Što |
|---|---|
| `20260507105640_InitialCreate` | Sve tablice |
| `20260507111713_AddSeedData` | Seed podatci |
| `20260507112553_SeedInitialData` | Δ: Tags + Reward |

### Nova migracija
```bash
dotnet ef migrations add <Naziv> \
  --project PointFlow.Model \
  --startup-project PointFlow.Web
```

### Primjena
```bash
dotnet ef database update \
  --project PointFlow.Model \
  --startup-project PointFlow.Web
```

### Vraćanje
```bash
dotnet ef database update <PrethodnaMigracija> \
  --project PointFlow.Model \
  --startup-project PointFlow.Web
```

---

## Seed podatak

Radi se u `OnModelCreating` s `HasData()`. Svaki entitet mora imati sve `[Required]` polja.

**Primjer:**
```csharp
modelBuilder.Entity<AppUser>().HasData(new AppUser
{
    Id = 4,
    Username = "korisnik",
    Email = "mail@example.com",
    TotalPointsEarned = 0,
    CurrentBalance = 0,
    CreatedAt = new DateTime(2026, 1, 1)
});
```

**Napomena:** `Reward.UnlockedAt` je `DateTime` (nije nullable) — koristi placeholder: `new DateTime(2026, 3, 1)`

---

## LINQ upiti u controllerima

### Registracija (DI pattern)
```csharp
public class TaskController : Controller
{
    private readonly PointFlowDbContext _dbContext;

    public TaskController(PointFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
```

### Primjeri s Include
```csharp
// Task s korisnikom i kategorijom
_dbContext.Tasks
    .Include(t => t.AppUser)
    .Include(t => t.Category)
    .FirstOrDefault(t => t.Id == id);

// Kategorija s taskovima
_dbContext.Categories
    .Include(c => c.Tasks)
    .FirstOrDefault(c => c.Id == id);

// Tag s M:N taskovima
_dbContext.Tags
    .Include(t => t.Tasks)
    .FirstOrDefault(t => t.Id == id);

// PomodoroSession s kvizovima
_dbContext.PomodoroSessions
    .Include(s => s.Quizzes)
    .FirstOrDefault(s => s.Id == id);
```

---

## Česte greške

| Greška | Rješenje |
|---|---|
| `NullReferenceException` na propertiima | Dodaj `.Include(...)` |
| `FK constraint violated` | Briši djecu prije roditelja |
| `Cannot insert duplicate key` u seed | Id-jevi u `HasData` moraju biti jedinstveni |
| Migracija ne vidi promjenu | Koristi `--startup-project PointFlow.Web` |
| Docker nije dostupan | `docker start sqlserver-pointflow` |
