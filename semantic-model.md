# Semantic Model — PointFlow

## Entiteti

### AppUser
Korisnik sustava koji skuplja bodove izvršavanjem taskova i može ih potrošiti na nagrade.

| Svojstvo | Tip | Opis |
|---|---|---|
| `Id` | int | Primarni ključ |
| `Username` | string (max 50) | Jedinstveno korisničko ime |
| `Email` | string (max 100) | E-mail adresa |
| `TotalPointsEarned` | int | Ukupno zarađeni bodovi (kumulativno) |
| `CurrentBalance` | int | Trenutno raspoloživo stanje bodova |
| `CreatedAt` | DateTime | Datum registracije |

---

### Category
Kategorija kojoj pripada task (npr. Learning, Fitness, Work).

| Svojstvo | Tip | Opis |
|---|---|---|
| `Id` | int | Primarni ključ |
| `Name` | string (max 100) | Naziv kategorije |
| `Description` | string (max 500) | Kratki opis kategorije |

---

### PointTask
Zadatak koji korisnik izvršava kako bi zaradio bodove.

| Svojstvo | Tip | Opis |
|---|---|---|
| `Id` | int | Primarni ključ |
| `Title` | string (max 200) | Naslov taska |
| `Description` | string (max 1000) | Detaljni opis |
| `PointsReward` | int | Broj bodova koji se dobiva izvršavanjem |
| `IsCompleted` | bool | Je li task završen |
| `Priority` | TaskPriority (enum) | Prioritet: Low / Medium / High |
| `CreatedAt` | DateTime | Datum kreiranja |
| `AppUserId` | int (FK) | Vlasnik taska |
| `CategoryId` | int (FK) | Kategorija taska |

---

### Tag
Oznaka koja se može dodijeliti većem broju taskova (folksonomija).

| Svojstvo | Tip | Opis |
|---|---|---|
| `Id` | int | Primarni ključ |
| `Name` | string (max 50) | Naziv taga (npr. "Study", "Health") |

---

### PomodoroSession
Zapis o jednoj Pomodoro radnoj sesiji vezanoj uz određeni task.

| Svojstvo | Tip | Opis |
|---|---|---|
| `Id` | int | Primarni ključ |
| `StartTime` | DateTime | Početak sesije |
| `EndTime` | DateTime | Kraj sesije |
| `DurationMinutes` | int | Trajanje u minutama |
| `LearnedNotes` | string (max 2000) | Bilješke o naučenom |
| `IsQuizPassed` | bool | Je li kviz položen |
| `PointTaskId` | int (FK) | Task na koji se odnosi sesija |

---

### Quiz
Jedno pitanje kviza vezano uz Pomodoro sesiju.

| Svojstvo | Tip | Opis |
|---|---|---|
| `Id` | int | Primarni ključ |
| `Question` | string (max 500) | Tekst pitanja |
| `ExpectedAnswer` | string (max 1000) | Očekivani točan odgovor |
| `UserAnswer` | string (max 1000) | Korisnikov odgovor |
| `PomodoroSessionId` | int (FK) | Sesija kojoj pitanje pripada |

---

### Reward
Nagrada koju korisnik može otključati trošenjem bodova.

| Svojstvo | Tip | Opis |
|---|---|---|
| `Id` | int | Primarni ključ |
| `Name` | string (max 100) | Naziv nagrade |
| `Description` | string (max 500) | Opis nagrade |
| `PointsCost` | int | Potreban broj bodova za otključavanje |
| `IsLocked` | bool | Je li nagrada još zaključana |
| `UnlockedAt` | DateTime | Datum otključavanja (ako je otključana) |
| `AppUserId` | int (FK) | Korisnik koji posjeduje nagradu |

---

## Relacije

```
AppUser ──────────── 1:N ──────────── PointTask
AppUser ──────────── 1:N ──────────── Reward
Category ─────────── 1:N ──────────── PointTask
PointTask ────────── 1:N ──────────── PomodoroSession
PointTask ────────── N:M ──────────── Tag          (join tablica: PointTaskTags)
PomodoroSession ──── 1:N ──────────── Quiz
```

### Detalji veza

| Relacija | Tip | FK | Brisanje |
|---|---|---|---|
| `AppUser` → `PointTask` | 1:N | `PointTask.AppUserId` | Cascade |
| `AppUser` → `Reward` | 1:N | `Reward.AppUserId` | Cascade |
| `Category` → `PointTask` | 1:N | `PointTask.CategoryId` | Cascade |
| `PointTask` → `PomodoroSession` | 1:N | `PomodoroSession.PointTaskId` | Cascade |
| `PointTask` ↔ `Tag` | N:M | join: `PointTaskTags` | Cascade |
| `PomodoroSession` → `Quiz` | 1:N | `Quiz.PomodoroSessionId` | Cascade |

---

## Enum: TaskPriority

| Vrijednost | Opis |
|---|---|
| `Low` (0) | Nizak prioritet |
| `Medium` (1) | Srednji prioritet |
| `High` (2) | Visok prioritet |
