﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizzes.Common.Helpers
{
    public static class TokenLifetimeValidator
    {
        public static bool Validate(
        DateTime? notBefore,
        DateTime? expires,
        SecurityToken tokenToValidate,
        TokenValidationParameters @param
    )
        {
            return (expires != null && expires > DateTime.UtcNow);
        }
    }
}
