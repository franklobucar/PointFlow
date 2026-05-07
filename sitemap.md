# Sitemap — PointFlow

Popis svih postojećih akcija i svih dostupnih URL varijanti koje ih mapiraju:
- semantičke custom rute iz `Program.cs`
- fallback varijante iz default rute `{controller=Home}/{action=Index}/{id?}`

---

## HomeController

| Akcija | Sve URL varijante | View |
|---|---|---|
| `Index` | `/dashboard`, `/`, `/Home`, `/Home/Index` | `Views/Home/Index.cshtml` |
| `Privacy` | `/Home/Privacy` | `Views/Home/Privacy.cshtml` |
| `Error` | `/Home/Error` | `Views/Shared/Error.cshtml` |

---

## TaskController

| Akcija | Sve URL varijante | View |
|---|---|---|
| `Index` | `/tasks`, `/Task`, `/Task/Index` | `Views/Task/Index.cshtml` |
| `Details(int id)` | `/tasks/{id:int}`, `/Task/Details/{id}` | `Views/Task/Details.cshtml` |

Podaci koje `Details` učitava: `PointTask` + `Include(AppUser)` + `Include(Category)`.

---

## CategoryController

| Akcija | Sve URL varijante | View |
|---|---|---|
| `Index` | `/categories`, `/Category`, `/Category/Index` | `Views/Category/Index.cshtml` |
| `Details(int id)` | `/categories/{id:int}`, `/Category/Details/{id}` | `Views/Category/Details.cshtml` |

Podaci koje `Details` učitava: `Category` + `Include(Tasks)`.

---

## UserController

| Akcija | Sve URL varijante | View |
|---|---|---|
| `Index` | `/User`, `/User/Index` | `Views/User/Index.cshtml` |
| `Details(int id)` | `/User/Details/{id}` | `Views/User/Details.cshtml` |

Podaci koje `Details` učitava: `AppUser` + `Include(Tasks)` + `Include(Rewards)`.

---

## RewardController

| Akcija | Sve URL varijante | View |
|---|---|---|
| `Index` | `/Reward`, `/Reward/Index` | `Views/Reward/Index.cshtml` |
| `Details(int id)` | `/Reward/Details/{id}` | `Views/Reward/Details.cshtml` |

---

## TagController

| Akcija | Sve URL varijante | View |
|---|---|---|
| `Index` | `/Tag`, `/Tag/Index` | `Views/Tag/Index.cshtml` |
| `Details(int id)` | `/Tag/Details/{id}` | `Views/Tag/Details.cshtml` |

Podaci koje `Details` učitava: `Tag` + `Include(Tasks)` (M:N veza).

---

## PomodoroSessionController

| Akcija | Sve URL varijante | View |
|---|---|---|
| `Index` | `/PomodoroSession`, `/PomodoroSession/Index` | `Views/PomodoroSession/Index.cshtml` |
| `Details(int id)` | `/PomodoroSession/Details/{id}` | `Views/PomodoroSession/Details.cshtml` |

Podaci koje `Details` učitava: `PomodoroSession` + `Include(Quizzes)`.

---

## QuizController

| Akcija | Sve URL varijante | View |
|---|---|---|
| `Index` | `/quizzes`, `/Quiz`, `/Quiz/Index` | `Views/Quiz/Index.cshtml` |
| `Details(int id)` | `/quizzes/{id:int}`, `/Quiz/Details/{id}` | `Views/Quiz/Details.cshtml` |
| `Create()` GET/POST | `/quizzes/new`, `/Quiz/Create` | `Views/Quiz/Create.cshtml` |
| `Edit(int id)` GET/POST | `/quizzes/{id:int}/edit`, `/Quiz/Edit/{id}` | `Views/Quiz/Edit.cshtml` |

Podaci koje `Index` i `Details` učitavaju: `Quiz` + `Include(PomodoroSession)`.

Forma (`Create` i `Edit`) koristi shared partial: `Views/Quiz/_QuizForm.cshtml`.

---

## Routing redoslijed (Program.cs)

Rute se evaluiraju ovim redoslijedom:

1. `dashboard` → `GET /dashboard`
2. `tasks` → `GET /tasks`
3. `task-details` → `GET /tasks/{id:int}`
4. `categories` → `GET /categories`
5. `category-details` → `GET /categories/{id:int}`
6. `quizzes` → `GET /quizzes`
7. `quiz-create` → `GET|POST /quizzes/new`
8. `quiz-details` → `GET /quizzes/{id:int}`
9. `quiz-edit` → `GET|POST /quizzes/{id:int}/edit`
10. `default` → `GET /{controller=Home}/{action=Index}/{id?}`

Napomena: za akcije tipa `Details(int id)` URL mora sadržavati `id`; iako default ruta ima opcionalni `{id?}`, te akcije funkcionalno ovise o prisutnom `id` parametru.
