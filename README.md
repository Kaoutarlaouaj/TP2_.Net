🚀 Authentification JWT - Projet .NET
Bienvenue dans le projet Authentification JWT ! Ce projet implémente un système d'authentification basé sur JWT (JSON Web Tokens) pour une application .NET avec les bonnes pratiques de sécurité. Il est constitué de trois parties : Web API, Service, et Data Access Layer (DAL).

🎯 Objectif du Projet
Ce projet permet de gérer l'authentification des utilisateurs à l'aide de JSON Web Tokens (JWT) pour sécuriser les appels API. Il inclut des fonctionnalités telles que l'inscription, la connexion, et l'accès à des endpoints protégés via des tokens JWT.

🛠️ Prérequis
Avant de commencer, tu dois avoir ces outils installés sur ta machine :

.NET SDK (version 6 ou supérieure)

Git

Visual Studio ou Visual Studio Code pour éditer le code

🚶‍♂️ Étapes d'Installation
1. Cloner le projet
Tout d'abord, clone ce dépôt sur ton ordinateur avec cette commande :

bash
Copier
Modifier
git clone https://github.com/ton-utilisateur/TP2_.Net.git
2. Ouvrir la solution dans Visual Studio
Ouvre le fichier Authentification.JWT.sln dans Visual Studio ou Visual Studio Code. Cela permettra de charger tous les projets sous la solution.

3. Restaurer les packages NuGet
Ensuite, tu dois restaurer les packages NuGet nécessaires. Tu peux le faire avec cette commande :

bash
Copier
Modifier
dotnet restore
4. Lancer l'application
Une fois les dépendances installées, tu peux lancer le projet avec la commande :

bash
Copier
Modifier
dotnet run
Cela va démarrer ton application sur https://localhost:5001.

🔐 Fonctionnalités
Voici les principales fonctionnalités du projet :

Inscription des utilisateurs : Crée un nouvel utilisateur avec un nom d'utilisateur, un email, et un mot de passe.

Connexion des utilisateurs : Authentifie les utilisateurs via leur nom d'utilisateur et mot de passe, puis génère un token JWT.

Endpoints protégés : Accède à des ressources protégées en fournissant le token JWT dans les en-têtes de requête.

📚 Endpoints API
1. Register (Inscription)
Méthode : POST

URL : /api/auth/register

Corps :

json
Copier
Modifier
{
  "username": "nouvelutilisateur",
  "email": "email@exemple.com",
  "password": "motdepasse"
}
Réponse : Détails de l'utilisateur inscrit.

2. Login (Connexion)
Méthode : POST

URL : /api/auth/login

Corps :

json
Copier
Modifier
{
  "username": "utilisateur",
  "password": "motdepasse"
}
Réponse : Token JWT généré.

3. Protected Endpoint (Endpoint Protégé)
Méthode : GET

URL : /api/auth/protected

En-têtes :

plaintext
Copier
Modifier
Authorization: Bearer <ton-token-jwt>
Réponse : Message indiquant que l'utilisateur a accès à l'endpoint protégé.

🧑‍💻 Comment utiliser le projet
Inscription : Envoie une requête POST à /api/auth/register pour créer un utilisateur.

Connexion : Envoie une requête POST à /api/auth/login pour obtenir un token JWT.

Accès aux endpoints protégés : Utilise ce token JWT dans l'en-tête Authorization pour accéder à des ressources sécurisées via l'API.

📄 Configuration NLog
Ce projet utilise NLog pour gérer les logs de l'application. Les logs sont enregistrés dans un fichier app.log situé dans le répertoire logs.

Pour personnaliser les logs :
Ouvre le fichier nlog.config à la racine du projet.

Modifie la configuration des cibles (console, fichier, etc.) selon tes préférences.

⚙️ Technologies utilisées
.NET 6+

JWT (JSON Web Token) pour l'authentification

NLog pour la gestion des logs

AutoMapper pour la gestion des mappages entre entités et DTOs
