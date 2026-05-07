---
name: pointflow-routing
description: Routing skill za PointFlow. Koristi kada treba dodati ili izmijeniti custom route u Program.cs, mapirati URL na controller akciju, dokumentirati sitemap.md ili dodati route constraints.
argument-hint: Navedi URL uzorak i ciljnu akciju (controller/action) te eventualna ograničenja.
---

# PointFlow Routing Skill

## Kada koristiti
- Dodavanje nove semantičke rute u PointFlow.Web/Program.cs
- Definiranje URL patterna s parametrima i constraintima
- Provjera redoslijeda ruta (specificnije rute prije default)
- Sinkronizacija route promjena sa sitemap.md

## Pravila
1. Semantičke custom rute mapiraj prije default rute.
2. Koristi jasne nazive ruta (`quiz-details`, `task-details`, `categories`, ...).
3. Za ID parametre koristi constraint gdje ima smisla: `{id:int}`.
4. Default rutu ostavi kao fallback: `{controller=Home}/{action=Index}/{id?}`.
5. Nakon svake route promjene ažuriraj sitemap.md.

## Predložak
```csharp
app.MapControllerRoute(
    name: "quiz-details",
    pattern: "quizzes/{id:int}",
    defaults: new { controller = "Quiz", action = "Details" });
```

## Checklista
- Ruta je dodana prije default rute.
- URL se ne preklapa neželjeno s postojećim rutama.
- Controller akcija i view postoje.
- sitemap.md je ažuriran.
