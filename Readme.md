
# GraphQL API

Ukázkový projekt, vytvořený na základě oficiálního [workshopu](https://github.com/ChilliCream/graphql-workshop).

Příkazy pro vytvoření databáze

```console
dotnet build GraphQL
dotnet ef migrations add Initial --project GraphQL
dotnet ef database update --project GraphQL
```

Spuštění aplikace

```console
dotnet run --project GraphQL
```

## Vytvoření dat (mutace)

Vytvoření uživatele.

```graphql
mutation AddUser {
  addUser(input: {
    name: "User"
    email: "user@email.com"
  }) {
    user {
      id
    }
  }
}
```

Vytvoření objednávky.

```graphql
mutation AddOrder {
  addOrder(input: {
    orderDate:  "2020-10-14 12:00:00.0"
  }) {
   order {
     id
   }
  }
}
```

## Dotazy nad daty (query)

Výběr id a jmen všech uživatelů

```graphql
query {
  users {
    id
    name
  }
}

```

Výběr id a data všech objednávek

```graphql
query {
  orders {
    id
    orderDate
  }
}
```

Výběr uživatele podle id.

```graphql
query {
  user(id: "VXNlcgppMQ==") {
    name
    email
  }
}
```

Paralelní vykonávání dotazů.

```graphql
query GetUserNamesInParallel {
  a: users {
    name
  }
  b: users {
    name
  }
  c: users {
    name
  }
}
```

Vnořené dotazy (spojení tabulek)

```graphql
query {
  users {
    name
    orders {
      orderDate
    }
  }
}
```



