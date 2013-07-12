﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YouScribe.Rest.Models;
using YouScribe.Rest.Models.Accounts;

namespace YouScribe.Rest
{
    public interface IAccountRequest : IYouScribeRequest
    {
        /// <summary>
        /// Register a new account
        /// The UserName, Email and Password fields are required
        /// </summary>
        /// <param name="account">The account information</param>
        /// <returns>Returns the account created</returns>
        AccountModel Create(AccountModel account);

        /// <summary>
        /// Update your account
        /// </summary>
        /// <param name="account">The account information</param>
        /// <returns>True if success</returns>
        bool Update(AccountModel account);

        /// <summary>
        /// Set the spoken languages of the account
        /// </summary>
        /// <param name="languages">A two or three letter language iso code</param>
        /// <returns>True if success</returns>
        bool SetSpokenLanguages(IEnumerable<string> languages);

        /// <summary>
        /// Update account picture
        /// </summary>
        /// <param name="uri">The uri of the photo</param>
        /// <returns>True if success</returns>
        bool UploadPicture(Uri uri);

        /// <summary>
        /// Update account picture
        /// </summary>
        /// <param name="image">The image information of the photo. The format accepetd are gif / jpeg / png / bmp </param>
        /// <returns>True if success</returns>
        bool UploadPicture(FileModel image);

        /// <summary>
        /// Delete the account photo
        /// </summary>
        /// <returns></returns>
        bool DeletePicture();
    }
}