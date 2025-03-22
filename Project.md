![Github Banner](images/banner_dark.png#gh-dark-mode-only)
![Github Banner](images/banner_light.png#gh-light-mode-only)

# DevEnv Project (And other integrations like GNPM)
I don't currently have much time to work on DevEnv but here's what I want this project to turn out like:

- Cross-platform, different engines for different platforms
- Highly-customisable and modifiable (Plugins, possibly)
- Custom configuration language (Like importing other config files in one file, and then using variables from it, etc...)
- Developer-friendly (Obviously) and beginner-friendly (Easy to use GUI, CLI, and other interfaces)
- Quick and easy to get set up and run
- Self-updating
- Minimising impact on Node modules
- Support for every programming language, with all of the different kinds of compilers
- Detections for all of the IDEs, compilers, and any other developer tools
- Support for Dev Drive (Windows only, but separate partition support for Linux)
  - Use this to cache node modules, and only have node modules in the actual project folder when it's in use (Since node modules are huge when you start having 100s of them)
  - Use this to store NuGet packages, Cargo packages, and anything else
  - DevEnv should be able to create and get the Dev Drive/partition set up and manage it (Optional)
- Integrate with Git (Allow you to open GitHub Desktop, Gittyup, or anything else)
- Allow you to install everything needed for one specific workflow with a few simple clicks
  - Choose your IDE, choose the language, choose your compiler, and hit `Install`
  - Add config files so for when you are setting up a new computer, you can simply install DevEnv, import the config and let it figure the rest out for you.

## What is GNPM?
GNPM is a project I'm planning to make, which is called **G**raphical **N**ode **P**ackage **M**anager, and I would like to integrate this with DevEnv so make working with Node.JS easy.

## Project templates
I'd like to have global templates for different types of projects for all languages and compilers.
This would make it easy for people to quickly get started, and it should work with all supported IDEs.

# Getting involved
If you would like to get involved, feel free to fork this repository and create a new branch on your fork
- `feature/feature-name` if you're adding a feature
- `bug/bug-name` if you're fixing a bug
- `docs/anything` if you're adding/modifying/fixing docs

If you'd like to contact me you can:
- Head to https://wtdawson.info/contact
- DM me on Discord (My username is @wtdawson9)
- Email me (My email is on the page at https://wtdawson.info/contact)