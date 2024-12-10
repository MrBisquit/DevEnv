# Scanning
DevEnv can scan for certain things installed on your computer and even check the versions of some of them.

## Supported

ID scheme: `CCCFFF`
- `CCC`: 3 characters for the type
  - `IDE`: IDE/Editing software (E.g. VSCode, Visual Studio)
  - `PLC`: Programming language compier/interpreter (E.g. GCC, G++, CMake, Python)
  - `FWK`: Framework (E.g. Node.JS)
- `FFF`: 3 characters for the name of it, e.g.
  - `VSC`: VSCode
  - `MVS`: VS
  - `NJS`: Node.JS
  - `PYN`: Python

| Name    | ID     | Notes |
| :------ | :----- | :---- |
| VSCode  | IDEVSC |       |
| VS      | IDEMVS |       |
| Node.JS | FWKNJS |       |
| Python  | PLCPYN |       |

### Engine support

- `✔️` Yes
- `⏳` In progress
- `❌` Not supported
- `-` Platform not supported

| ID      | Windows engine | Linux engine | OSX Engine | FreeBSD Engine |
| :------ | :------------: | :----------: | :--------: | :------------: |
| VSCode  |       ⏳        |      ⏳       |     -      |       -        |
| VS      |       ⏳        |      ⏳       |     -      |       -        |
| Node.JS |       ⏳        |      ⏳       |     -      |       -        |
| Python  |       ⏳        |      ⏳       |     -      |       -        |

## Structure

In the `scanning.json` file, each part will be set out like this, using VSCode as the example:

```js
{
    "name": "VSCode",                               // Name
    "ID": "IDEVSC",                                 // ID
    "checks": [
        {
            "type": 0,                              // Type, see meaning below
            "file": "C:\\Users\\{UserName}\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe"
        },
        {
            "type": 1,                              // Type, see meaning below
            "command": "code --version",            // Command
            "expected": "([0-9]+(\\.[0-9]+)+)"      // Expected output (Supports regex)
        }
    ]
}
```

### `type`
There are different types of checks:

- `0`: Standard checking if a file or directory exists
  - Either enter `file` or `directory`, supports filling in details such as `UserName`
- `1`: Using the command line and expected output (supports regex)