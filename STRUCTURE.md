# PointFlow — Struktura koda

## Projekti

```
PointFlow.slnx
├── PointFlow.Model/          # domenski sloj (entiteti)
└── PointFlow.ConsoleApp/     # koncolna aplikacija (seed + prikaz)
```

---

## PointFlow.Model

### Enum

#### `TaskPriority`
| Vrijednost |
|------------|
| `Low`      |
| `Medium`   |
| `High`     |

---

### Klase

#### `AppUser`
| Svojstvo            | Tip                | Opis                          |
|---------------------|--------------------|-------------------------------|
| `Id`                | `int`              | Primarni ključ                |
| `Username`          | `string`           |                               |
| `Email`             | `string`           |                               |
| `TotalPointsEarned` | `int`              | Ukupno zarađenih bodova       |
| `CurrentBalance`    | `int`              | Trenutni saldo bodova         |
| `CreatedAt`         | `DateTime`         |                               |
| `Tasks`             | `List<PointTask>`  | 1-N: AppUser → PointTask      |
| `Rewards`           | `List<Reward>`     | 1-N: AppUser → Reward         |

---

#### `Category`
| Svojstvo      | Tip               | Opis                     |
|---------------|-------------------|--------------------------|
| `Id`          | `int`             | Primarni ključ           |
| `Name`        | `string`          |                          |
| `Description` | `string`          |                          |
| `Tasks`       | `List<PointTask>` | 1-N: Category → PointTask |

---

#### `PointTask`
| Svojstvo           | Tip                      | Opis                             |
|--------------------|--------------------------|----------------------------------|
| `Id`               | `int`                    | Primarni ključ                   |
| `Title`            | `string`                 |                                  |
| `Description`      | `string`                 |                                  |
| `PointsReward`     | `int`                    | Broj bodova za završetak         |
| `IsCompleted`      | `bool`                   |                                  |
| `Priority`         | `TaskPriority`           | Low / Medium / High              |
| `CreatedAt`        | `DateTime`               |                                  |
| `AppUserId`        | `int`                    | FK → AppUser                     |
| `AppUser`          | `AppUser`                | 1-N: AppUser → PointTask         |
| `CategoryId`       | `int`                    | FK → Category                    |
| `Category`         | `Category`               | 1-N: Category → PointTask        |
| `Tags`             | `List<Tag>`              | N-N: PointTask ↔ Tag             |
| `PomodoroSessions` | `List<PomodoroSession>`  | 1-N: PointTask → PomodoroSession |

---

#### `PomodoroSession`
| Svojstvo          | Tip            | Opis                              |
|-------------------|----------------|-----------------------------------|
| `Id`              | `int`          | Primarni ključ                    |
| `StartTime`       | `DateTime`     |                                   |
| `EndTime`         | `DateTime`     |                                   |
| `LearnedNotes`    | `string`       | Bilješke iz sesije                |
| `IsQuizPassed`    | `bool`         |                                   |
| `DurationMinutes` | `int`          |                                   |
| `PointTaskId`     | `int`          | FK → PointTask                    |
| `PointTask`       | `PointTask`    | 1-N: PointTask → PomodoroSession  |
| `Quizzes`         | `List<Quiz>`   | 1-N: PomodoroSession → Quiz       |

---

#### `Quiz`
| Svojstvo            | Tip               | Opis                            |
|---------------------|-------------------|---------------------------------|
| `Id`                | `int`             | Primarni ključ                  |
| `Question`          | `string`          |                                 |
| `ExpectedAnswer`    | `string`          | Točan odgovor                   |
| `UserAnswer`        | `string`          | Odgovor korisnika               |
| `PomodoroSessionId` | `int`             | FK → PomodoroSession            |
| `PomodoroSession`   | `PomodoroSession` | 1-N: PomodoroSession → Quiz     |

---

#### `Reward`
| Svojstvo      | Tip        | Opis                        |
|---------------|------------|-----------------------------|
| `Id`          | `int`      | Primarni ključ              |
| `Name`        | `string`   |                             |
| `Description` | `string`   |                             |
| `PointsCost`  | `int`      | Cijena u bodovima           |
| `IsLocked`    | `bool`     | Je li nagrada zaključana    |
| `UnlockedAt`  | `DateTime` | Datum otključavanja         |
| `AppUserId`   | `int`      | FK → AppUser                |
| `AppUser`     | `AppUser`  | 1-N: AppUser → Reward       |

---

#### `Tag`
| Svojstvo | Tip               | Opis                    |
|----------|-------------------|-------------------------|
| `Id`     | `int`             | Primarni ključ          |
| `Name`   | `string`          |                         |
| `Tasks`  | `List<PointTask>` | N-N: Tag ↔ PointTask    |

---

## Relacije

```
AppUser ──< PointTask >── Category
                │
                ├──< PomodoroSession >── Quiz
                │
                └──< Tag (N-N)

AppUser ──< Reward
```

| Relacija                          | Tip  |
|-----------------------------------|------|
| AppUser → PointTask               | 1-N  |
| AppUser → Reward                  | 1-N  |
| Category → PointTask              | 1-N  |
| PointTask → PomodoroSession       | 1-N  |
| PomodoroSession → Quiz            | 1-N  |
| PointTask ↔ Tag                   | N-N  |

---

## PointFlow.ConsoleApp — Program.cs

Top-level script koji:

1. **Seed podataka** — kreira 4 taga, 3 kategorije, 3 korisnika (Ana, Marko, Petra) s ukupno 9 taskova, 2 pomodoro sesije, 2 kviza i 6 nagrada.
2. **Ispis** — za svakog korisnika ispisuje taskove (status, prioritet, kategorija, tagovi, pomodoro sesije + kvizovi) i nagrade.
3. **LINQ upiti**:
   | Upit | Opis |
   |------|------|
   | High priority taskovi | filtrirani po `TaskPriority.High`, sortirani po username |
   | Korisnici s > 100 bodova | sortirani silazno po `CurrentBalance` |
   | Taskovi s tagom "Study" | sortirani po username |
4. **`SimulirajSpremanjeAsync()`** — async metoda koja simulira spremanje s `Task.Delay(1000)`.
