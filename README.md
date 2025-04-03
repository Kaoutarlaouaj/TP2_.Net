🚀 Authentification JWT - Projet .NET

Bienvenue dans le projet d'Authentification JWT ! Ce projet met en place un système d'authentification basé sur JWT (JSON Web Tokens) pour une application .NET, en appliquant les bonnes pratiques de sécurité. Il est structuré en trois parties : Web API, Service, et Data Access Layer (DAL).

🎯 Objectif du Projet

Ce projet permet de gérer l'authentification des utilisateurs via JSON Web Tokens (JWT) pour sécuriser les appels API. Il inclut des fonctionnalités telles que l'inscription, la connexion, et l'accès à des endpoints protégés à l'aide de tokens JWT.

🛠️ Prérequis

Avant de commencer, assure-toi d'avoir installé les outils suivants sur ta machine :

.NET SDK (version 6 ou supérieure)

Git

Visual Studio ou Visual Studio Code pour éditer le code

🚶‍♂️ Étapes d'Installation

1. Cloner le projet

Clone ce dépôt sur ton ordinateur avec la commande suivante :

git clone https://github.com/Kaoutarlaouaj/TP2_.Net.git

2. Ouvrir la solution dans Visual Studio

Ouvre le fichier Authentification.JWT.sln dans Visual Studio ou Visual Studio Code. Cela va charger tous les projets sous la solution.

3. Restaurer les packages NuGet

Il est nécessaire de restaurer les packages NuGet nécessaires. Utilise la commande suivante pour le faire :

dotnet restore

4. Lancer l'application

Une fois les dépendances installées, lance l'application avec la commande :

dotnet run


🔐 Fonctionnalités

Voici les principales fonctionnalités du projet :

Inscription des utilisateurs : Permet de créer un nouvel utilisateur avec un nom d'utilisateur, un email, et un mot de passe.

Connexion des utilisateurs : Authentifie les utilisateurs avec leur nom d'utilisateur et mot de passe, puis génère un token JWT.

Endpoints protégés : Accède à des ressources protégées en incluant le token JWT dans les en-têtes de requête.

📚 Endpoints API

1. Inscription (Register)

Méthode : POST

URL : /api/auth/register

Corps :

{
  "username": "nouvelutilisateur",
  "email": "email@exemple.com",
  "password": "motdepasse"
}

Réponse : Détails de l'utilisateur inscrit.

2. Connexion (Login)

Méthode : POST

URL : /api/auth/login

Corps :

{
  "username": "utilisateur",
  "password": "motdepasse"
}

Réponse : Token JWT généré.

3. Endpoint Protégé (Protected Endpoint)

Méthode : GET

URL : /api/auth/protected

En-têtes :

Authorization: Bearer <ton-token-jwt>

Réponse : Message confirmant que l'utilisateur a accès à l'endpoint protégé.

🧑‍💻 Comment utiliser le projet

Inscription : Envoie une requête POST à /api/auth/register pour créer un utilisateur.

Connexion : Envoie une requête POST à /api/auth/login pour obtenir un token JWT.

Accès aux endpoints protégés : Utilise ce token JWT dans l'en-tête Authorization pour accéder aux ressources sécurisées via l'API.

📄 Configuration NLog

J'ai utilisé les logs pour informer l'utilisateur, ainsi que pour les avertissements et même pour les erreurs de manière personnalisée.

⚙️ Technologies utilisées

.NET 9

JWT (JSON Web Token) pour l'authentification

NLog pour la gestion des logs

AutoMapper pour la gestion des mappages entre entités et DTOs
