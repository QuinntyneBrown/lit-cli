# lit CLI
### Development tools and libraries specialized for lit-html

## Usage

```bash
lit help
```

### Generating and serving an lit-html project via a development server

```bash
lit new PROJECT-NAME
cd PROJECT-NAME
lit serve
```

Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

You can configure the default HTTP host and port used by the development server with two command-line options :

```bash
lit serve --host 0.0.0.0 --port 4201
```

You can find all possible blueprints in the table below:

| Scaffold                                               | Usage                             |
| ------------------------------------------------------ | --------------------------------- |
| Component    | `lit g component my-new-component` |
| Directive    | `lit g directive my-new-directive` |
| Service      | `lit g service my-new-service`     |
| Class        | `lit g class my-new-class`         |
| Interface    | `lit g interface my-new-interface` |
| Enum         | `lit g enum my-new-enum`           |
