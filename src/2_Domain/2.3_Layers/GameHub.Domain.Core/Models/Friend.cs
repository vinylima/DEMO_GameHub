
using System;

using GameHub.Domain.Core.Collections;
using GameHub.Domain.Core.Scopes.ExecutionResultScopes;
using GameHub.Domain.Core.Validations;
using GameHub.Shared.Kernel.Core.Enums;
using GameHub.Shared.Kernel.Core.Interfaces.Domain;
using GameHub.Shared.Kernel.Core.ValueObjects;

namespace GameHub.Domain.Core.Models
{
    public class Friend : IModel
    {
        public Guid FriendId { get; private set; }
        public string Name { get; private set; }
        public string ImagePath { get; private set; }
        public string Email { get; private set; }
        public ReputationLevel ReputationLevel { get; private set; }

        public LoanCollection Loans { get; private set; }

        #region Constructors

        public Friend()
        {
            this.FriendId = Guid.NewGuid();
        }

        public Friend(Guid friendId, string name, string imagePath, string email)
        {
            this.FriendId = friendId;
            this.Name = name;
            this.ImagePath = imagePath;
            this.Email = email;
        }

        #endregion

        #region Factories

        public static Friend CreateNew(Guid friendId, string name, string imagePath, string email)
        {
            return new Friend
            {
                FriendId = friendId,
                Name = name,
                ImagePath = imagePath,
                Email = email,
            };
        }

        public static Friend CreateNew(string name, string imagePath, string email)
        {
            return new Friend
            {
                FriendId = Guid.NewGuid(),
                Name = name,
                ImagePath = imagePath,
                Email = email,
            };
        }

        #endregion

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }

        public ExecutionResult<bool> IsValid()
        {
            var result = new ExecutionResult<bool>();

            result.Merge(
                new FriendValidation().Validate(this)
            );
            
            return result;
        }

        public Guid GetId()
        {
            return this.FriendId;
        }
    }
}