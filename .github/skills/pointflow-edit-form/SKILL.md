---
name: pointflow-edit-form
description: Skill za izradu create/edit Razor formi u PointFlow.Web koristeći EF, validaciju i shared partial formu.
argument-hint: Navedi entitet i koja polja su obavezna za create/edit formu.
---

# PointFlow Edit Form Skill

## Kada koristiti
- Dodavanje `Create` i `Edit` stranica za entitet
- Uvođenje shared partial forme (`_EntityForm.cshtml`) za izbjegavanje duplikacije
- Povezivanje formi s EF spremanjem i validacijom (`ModelState`)

## Standardni koraci
1. Controller:
   - `Create` GET + POST
   - `Edit` GET + POST
   - `[ValidateAntiForgeryToken]` za POST akcije
2. View-ovi:
   - `Create.cshtml` i `Edit.cshtml`
   - shared partial, npr. `_QuizForm.cshtml`
3. Forma:
   - `asp-for` input/textarea/select
   - `asp-validation-for` i `asp-validation-summary`
4. Nakon uspjeha:
   - `Create` -> redirect na listu
   - `Edit` -> redirect na details ili listu

## Predložak POST akcije
```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Quiz quiz)
{
    if (id != quiz.Id) return BadRequest();

    if (!ModelState.IsValid)
    {
        return View(quiz);
    }

    await _quizRepository.UpdateAsync(quiz);
    return RedirectToAction(nameof(Details), new { id = quiz.Id });
}
```

## Checklista
- Forma koristi tag helpere (`asp-for`).
- Model validacija radi.
- `Create` i `Edit` dijele isti partial.
- Nema dupliranog form markup-a.
