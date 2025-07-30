# Lecture des fichiers de sauvegarde avec PKHeX.Core

## Introduction
Ce projet utilise la librairie PKHeX.Core pour lire et manipuler des fichiers de sauvegarde de jeux vidéo Pokémon (Game Boy Advance, Nintendo DS, 3DS, Switch, etc.). Cette documentation explique comment détecter, charger et exploiter ces fichiers dans votre application.

---

## 1. Fonction principale à utiliser

Pour charger un fichier de sauvegarde, utilisez :

```csharp
object? obj = FileUtil.GetSupportedFile("chemin/vers/ma.sav");
```
- Cette fonction détecte automatiquement le type de fichier et retourne un objet adapté.
- Si c'est une sauvegarde, le retour sera un objet dérivé de `SaveFile`.

---

## 2. Détection et instanciation

En interne, la détection du type de sauvegarde se fait via :

```csharp
SaveFile? sav = SaveUtil.GetVariantSAV(Memory<byte> data);
```
- Retourne un objet du type approprié (`SAV3RS`, `SAV4Pt`, `SAV5BW`, etc.), tous héritant de `SaveFile`.

---

## 3. Type d'objet obtenu

- **Type principal :** `SaveFile` (classe abstraite)
- **Types concrets :**
  - `SAV3RS`, `SAV4Pt`, `SAV5BW`, `SAV6XY`, `SAV7SM`, `SAV8SWSH`, `SAV9SV`, etc.
- Le type exact dépend du jeu détecté.

---

## 4. Fonctions et propriétés associées à `SaveFile`

Une fois le fichier chargé et casté en `SaveFile`, vous avez accès à :

- **Propriétés générales :**
  - `Version` (jeu/version)
  - `Generation` (génération)
  - `Inventory` (inventaire)
  - `OT`, `ID32`, `TID16`, `SID16` (infos dresseur)
  - `BoxCount`, `SlotCount`, etc.
- **Méthodes utiles :**
  - `Write()` : exporter la sauvegarde modifiée
  - `Clone()` : dupliquer l'objet
  - `GetString(...)`, `LoadString(...)` : décoder des chaînes internes
  - `SetData(...)` : injecter des données binaires

---

## 5. Exemple d’utilisation

```csharp
using PKHeX.Core;

object? obj = FileUtil.GetSupportedFile("chemin/vers/ma.sav");
if (obj is SaveFile sav)
{
    var version = sav.Version;
    var inventory = sav.Inventory;
    var trainerName = sav.OT;
    // ...
}
```

---

## 6. Résumé

- **Fonction d’entrée :** `FileUtil.GetSupportedFile(...)`
- **Type d’objet :** `SaveFile` (et dérivés)
- **Fonctions associées :** propriétés et méthodes de `SaveFile`

Pour plus de détails sur une génération ou un jeu précis, consultez la classe correspondante (`SAV4Pt`, `SAV5BW`, etc.).
