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