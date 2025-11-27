# Top-Down Survival Shooter

Jeu PC en vue top-down où le joueur doit survivre le plus longtemps
possible face à des vagues d'ennemis croissantes.

## Objectifs du jeu

-   Contrôler un personnage
-   Tirer vers le curseur
-   Survivre aux vagues
-   Améliorer sa puissance
-   Atteindre le meilleur temps de survie

## Technologies

-   Unity 2022+ LTS
-   C#
-   GitHub
-   Codex

## Structure du projet

    /Assets
      /Scripts
        /Player
          PlayerController.cs
          PlayerShoot.cs
          PlayerHealth.cs
        /Enemies
          EnemyAI.cs
          EnemySpawner.cs
          EnemyHealth.cs
        /Combat
          Bullet.cs
          DamageSystem.cs
        /Systems
          GameManager.cs
          UpgradeSystem.cs
        /UI
          HealthBar.cs
          GameOverUI.cs

## Fonctionnalités (MVP)

### Joueur

-   WASD
-   Tir direction souris
-   Vie + barre de vie

### Ennemis

-   IA simple
-   Dégâts au contact

### Vagues

-   Spawns progressifs\
-   Difficulté croissante

### Combat

-   Projectiles
-   Dégâts

### UI

-   HUD
-   Game Over
-   Restart

## Roadmap

### Sprint 1

-   PlayerController
-   PlayerShoot
-   Bullet

### Sprint 2

-   EnemyAI
-   EnemySpawner
-   Collisions

### Sprint 3

-   GameManager
-   UI
-   Restart

## Prompts Codex

### Créer un script

    Create a Unity C# script named PlayerController.cs.
    It must move a 2D top-down player using Rigidbody2D and WASD.
    Use clean code, comments, and expose tunable fields.
