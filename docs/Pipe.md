# Pipe messages
Pipe messages between the engine and the client are structured with the type of message and then the content in JSON separated by a semicolon,
e.g. `message;{ "message": "test" }`

## Types of messages
| Type       | Description                                                                  | Documentation              |
| :--------- | :--------------------------------------------------------------------------- | :------------------------- |
| `message`  | A simple message                                                             | [Documentation](#message)  |
| `ping`     | A ping to the server to check whether or not it's working                    | [Documentation](#ping)     |
| `progress` | Progress update                                                              | [Documentation](#progress) |
| `scan`     | Scans the computer for IDEs/Editors/Frameworks/Compilers/Interpreters/Etc... | [Documentation](#scan)     |

## Engine support

- `✔️` Yes
- `⏳` In progress
- `❌` Not supported
- `-` Platform not supported

| Type       | Windows engine | Linux engine | OSX Engine | FreeBSD Engine |
| :--------- | :------------: | :----------: | :--------: | :------------: |
| `scan`     |      ✔️      |      ⏳       |     -      |       -        |

## Messages

### `message`

### `ping`
**This will only be sent to the server**.
The server will respond with `pong` assuming that it's working correctly.

### `progress`
**This will only be sent from the server**.

The JSON structure is:
```js
{
    "value": 0,             // Number (Range: 0-100)
    "message": "",          // String
    "intermediate": false   // boolean
}
```

### `scan`
**This will only be sent to the server**.
This tells the engine to start scanning the computer for things such as:

- IDEs/Editors (E.g. VSCode, VS, Jetbrains IDEs)
  - And for VSCode, extensions
- Frameworks (E.g. Node.JS)
- Compilers/Interpreters (E.g. CMake, .NET, Python)

It will report back via the [`progress`](#progress) message.