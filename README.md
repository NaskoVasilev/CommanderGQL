# CommanderGQL
GraphQL API with .NET 6 and Hot Chocolate

## Queries
#### Get Platforms Query
- Request
```json
query {
	platform {
		id
		name
	}
}
```
- Response
```json
{
	"data": {
		"platform": [
			{
				"id": 7,
				"name": ".NET 6"
			},
			{
				"id": 8,
				"name": ".Docker"
			}
		]
	}
}
```
#### Get Commands query
- Request
```json
query{
	command{
		id
		howTo
		commandLine,
		platform {
			name
			id
		}
	}
}
```
- Response
```json
	"data": {
		"command": [
			{
				"id": 3,
				"howTo": "Build a project",
				"commandLine": "dotnet build",
				"platform": {
					"name": ".NET 6",
					"id": 7
				}
			},
			{
				"id": 4,
				"howTo": "Start a docker compose file",
				"commandLine": "docker-componse up",
				"platform": {
					"name": ".Docker",
					"id": 8
				}
			}
		]
	}
}
```
#### Parallel Platforms
- Request
```json
query{
	a: platform{
		id
		name
	},
	b: platform{
		id
		name
	},
	c: platform{
		id
		name
	}
}
```
- Response
```json
{
	"data": {
		"a": [
			{
				"id": 7,
				"name": ".NET 6"
			},
			{
				"id": 8,
				"name": ".Docker"
			}
		],
		"b": [
			{
				"id": 7,
				"name": ".NET 6"
			},
			{
				"id": 8,
				"name": ".Docker"
			}
		],
		"c": [
			{
				"id": 7,
				"name": ".NET 6"
			},
			{
				"id": 8,
				"name": ".Docker"
			}
		]
	}
}
```
#### Get Platform Commands
- Request
```json
query{
	platform{
		id
		name
		commands {
			id
			howTo
		}
	}
}
```
- Response
```json
{
	"data": {
		"platform": [
			{
				"id": 7,
				"name": ".NET 6",
				"commands": [
					{
						"id": 3,
						"howTo": "Build a project"
					}
				]
			},
			{
				"id": 8,
				"name": ".Docker",
				"commands": [
					{
						"id": 4,
						"howTo": "Start a docker compose file"
					}
				]
			}
		]
	}
}
```
#### Filter request
- Request
```json
query {
	command(where: { platformId: { eq: 7 }}) {
		id
		platform {
			name
		}
		commandLine
		howTo
	}
}
```
- Response
```json
{
	"data": {
		"command": [
			{
				"id": 3,
				"platform": {
					"name": ".NET 6"
				},
				"commandLine": "dotnet build",
				"howTo": "Build a project"
			}
		]
	}
}
```
#### Sorting request
- Request
```json
query {
	platform(order: {name: ASC}) {
		name
	}
}
```
- Response
```json
{
	"data": {
		"platform": [
			{
				"name": ".Docker"
			},
			{
				"name": ".NET 6"
			}
		]
	}
}
```
## Mutations
#### Add Platform
- Request
```json
mutation {
	addPlatform(input: {
		name: "RedHat"
	}) {
		platform {
			name
		}
	}
}
```
- Response
```json
{
	"data": {
		"addPlatform": {
			"platform": {
				"name": "RedHat"
			}
		}
	}
}
```
#### Add Command
- Request
```json
mutation {
	addCommnad(input: {
		howTo: "Platform directory listing"
		commandLine: "ls"
		platformId: 7
	}) {
		command {
			howTo
			commandLine
			id
		}
	}
}
```
- Response
```json
{
	"data": {
		"addCommnad": {
			"command": {
				"howTo": "Platform directory listing",
				"commandLine": "ls",
				"id": 5
			}
		}
	}
}
```
## Subscriptions
```json
subscription {
  onPlatformAdded {
    id
    name
  }
}
```
```json
{
  "data": {
    "onPlatformAdded": {
      "id": 13,
      "name": "EF Core"
    }
  }
}
```
