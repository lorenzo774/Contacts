﻿using Contacts.Library;

namespace Contacts.CLI.Systems;

public interface IMessage
{
    void Help();
    void DisplayContacts(List<Contact> contacts);
}