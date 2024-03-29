﻿namespace CollaborativeMusicApp.Application.Common;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string username, string email);
}