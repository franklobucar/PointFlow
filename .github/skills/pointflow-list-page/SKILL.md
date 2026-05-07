---
name: pointflow-list-page
description: Skill za izradu Razor list stranica u PointFlow.Web. Koristi kada treba napraviti novu Index/list stranicu za entitet i povezati je s routingom i navigacijom.
argument-hint: Navedi entitet i koja polja treba prikazati u listi.
---

# PointFlow List Page Skill

## Kada koristiti
- Izrada nove list stranice (`Index`) za entitet (npr. Quiz, Reward, Tag)
- Povezivanje liste s controller akcijom i custom URL rutom
- Dodavanje linkova prema detaljima i create formi

## Standardni koraci
1. U controlleru dodaj `Index` akciju koja dohvaća kolekciju iz EF sloja.
2. U Program.cs dodaj semantičku rutu za listu (npr. `/quizzes`).
3. Kreiraj view `Views/<Entity>/Index.cshtml` s `@model IEnumerable<...>`.
4. Dodaj CTA za novu stavku (link prema `Create`).
5. U `_Layout.cshtml` dodaj navigacijsku stavku ako je nova sekcija aplikacije.
6. Ažuriraj sitemap.md.

## UI smjernice
- Koristi postojeće klase dizajna: `page-header`, `page-title`, `page-subtitle`, `fwd-link`, `empty-state`.
- Uvijek pokaži stanje kad je lista prazna.
- U listi prikaži najbitnija 2-4 podatka i akciju `Detalji`.

## Checklista
- `Index` radi bez greške.
- URL je semantički i dokumentiran.
- Lista ima linkove na `Details` i `Create`.
