﻿using HashidsNet;

namespace Queueomatic.Server.Services.HashIdService;

public class HashIdService : IHashIdService
{
	private readonly Hashids _hashids;

	public HashIdService(IConfiguration configuration)
	{
		var _salt = configuration.GetSection("HashIdKey").GetSection("Default").Value;
		_hashids = new Hashids(_salt, 6);
	}

	public string Encode(int id)
	{
		return _hashids.Encode(id);
	}

	public int Decode(string hash)
	{
        try
        {
            return _hashids.DecodeSingle(hash);
        }
        catch (NoResultException)
        {
            return -1;
        }
    }
}