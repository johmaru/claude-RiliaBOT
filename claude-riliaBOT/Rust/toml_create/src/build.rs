fn main() {
    csbindgen::Builder::default()
        .input_extern_file("lib.rs")
        .csharp_dll_name("TomlCreate")
        .generate_csharp_file("../Program.cs")
        .unwrap();
}