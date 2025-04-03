using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentification.JWT.DAL.Entities;
using Authentification.JWT.DAL.Repositories;
using AutoMapper;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;

namespace Authentification.JWT.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            _logger.LogInformation("Recherche de l'utilisateur : {Username}", username);
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                _logger.LogWarning("Utilisateur {Username} non trouvé", username);
                return null;
            }
            _logger.LogInformation("Utilisateur {Username} trouvé avec succès", username);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> RegisterUserAsync(string username, string email, string password)
        {
            _logger.LogInformation("Création d'un nouvel utilisateur : {Username}", username);
            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password)
            };

            await _userRepository.RegisterUserAsync(user);
            _logger.LogInformation("Utilisateur {Username} enregistré avec succès", username);
            return _mapper.Map<UserDto>(user);
        }

        public bool VerifyPassword(UserDto user, string password)
        {
            bool isValid = user.PasswordHash == HashPassword(password);
            if (isValid)
            {
                _logger.LogInformation("Vérification du mot de passe réussie pour l'utilisateur : {Username}", user.Username);
            }
            else
            {
                _logger.LogWarning("Échec de vérification du mot de passe pour l'utilisateur : {Username}", user.Username);
            }
            return isValid;
        }

        private string HashPassword(string password)
        {
            _logger.LogInformation("Hachage du mot de passe en cours...");
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashedPassword = Convert.ToBase64String(bytes);
            _logger.LogInformation("Mot de passe haché avec succès");
            return hashedPassword;
        }
    }
}
