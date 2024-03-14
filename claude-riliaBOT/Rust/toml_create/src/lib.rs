extern crate serde;
extern crate toml;

use serde::{Deserialize, Serialize};
use std::fs::{self, File};
use std::io::Write;

use std::path::Path;

#[derive(Debug, Serialize, Deserialize)]
struct Setting {
    role: String,
}

#[no_mangle]
pub extern "C" fn toml_control() -> Result<(), Box<dyn std::error::Error>> {
    let path = Path::new("setting.toml");
    if !path.is_file(){
        let setting = Setting {
            role: "user".to_string(),
        };
        let mut file = File::create("setting.toml").unwrap();
        let toml = toml::to_string(&setting).unwrap();
        write!(file, "{}", toml)?;
        file.flush()?;

        let foo: String = fs::read_to_string("setting.toml")?;
        let setting: Result<Setting, toml::de::Error> = toml::from_str(&foo);
        match setting {
            Ok(p) => println!("#Parsed TOML:\n{:#?}", p),
            Err(e) => panic!("Filed to parse TOML: {}", e),
        }
    }
    Ok(())
}