﻿using Contacts.Library;

namespace Contacts.CLI.Input;

public class ContactExtractor : IContactExtractor
{
    /// <summary>
    /// Throw custom exception if datetime format is invalid
    /// </summary>
    private DateTime GetBirthdate(string date)
    {
        bool canParse = DateTime.TryParse(date, out var birthDate);
        if (!canParse)
        {
            throw new InvalidDataException("Date format not valid");
        }

        return birthDate;
    }

    public Contact Extract(List<string> args)
    {
        if (args.Count == 0)
        {
            throw new Exception("No arguments specified");
        }

        var result = new Contact();
        try
        {
            result.FirstName = args[0];
            result.LastName = args[1];
            result.Birthdate = GetBirthdate(args[2]);
            result.Phone = args[3];
            result.Email = args[4];
        }
        catch (Exception e)
        {
            // Rethrow the error if birthdate format is invalid
            switch (e)
            {
                case InvalidDataException:
                    throw;
            }
        }
        return result;
    }
}