https://azuredevopslabs.com//labs/vstsextend/ansible/

https://github.com/microsoft/azuredevopslabs/tree/master/labs/vstsextend/ansible


az login

az account show

Conta do Azure
az account set --subscription "3323e547-1651-47e7-a768-6931436e3314"

az account list-locations -o table

# 1 - Criar uma service principal
az ad sp create-for-rbac --name AnsibleIAC

{
  "appId": "f5e7eb34-c005-4496-a7c6-69ebbc347be6",
  "displayName": "AnsibleIAC",
  "name": "http://AnsibleIAC",
  "password": "pP5PtFodZlL_UDKFp8_U9IdP7JR5NqtoYn",
  "tenant": "72f988bf-86f1-41af-91ab-2d7cd011db47"
}

# 2 - Criar a VM Linux e instalar o ansible
$rgName = "RG_Ansible"

az group create -l brazilsouth -n $rgName

az deployment group create --resource-group $rgName --template-file CreateAnsibleMachine.json --parameters CreateAnsibleMachine.parameters.json --debug

# 3 - Conectar na maquina linux via SSH (#P@ssw0rd123456#)
ssh leandro@191.232.245.195

# 4 - Criar uma pasta .azure
mkdir ~/.azure

# 5 - Criar um arquivo Credentials com as configuracaoes do Service Principal criada no passo 1
nano ~/.azure/credentials

[default]
subscription_id=3323e547-1651-47e7-a768-6931436e3314
client_id=f5e7eb34-c005-4496-a7c6-69ebbc347be6
secret=pP5PtFodZlL_UDKFp8_U9IdP7JR5NqtoYn
tenant=72f988bf-86f1-41af-91ab-2d7cd011db47

# 6 - Gerar as chaves Privada e Publica

ssh-keygen -t rsa

chmod 755 ~/.ssh

touch ~/.ssh/authorized_keys

chmod 644 ~/.ssh/authorized_keys

ssh-copy-id leandro@127.0.0.1

# 7 - Private Key
cat ~/.ssh/id_rsa

-----BEGIN RSA PRIVATE KEY-----
MIIEpAIBAAKCAQEAuPMXnUh+PO0gNNxa+HTGE98jN5gdtum3dRXUxDwYKU+8ZaOM
GZHDJziW+qivStslzD3jmZalK7ArGqPLCgEyEOxIszsdDjzgXXjMO7aQLMSZws/4
NZNZKB1aAzD+NkAHJMnjjRmv6XW1ydJn9jYDltvqNicwkjVWAPVz05MAjb8520zi
BXmnftpKsP8V8LXk9v5UfpvpJi9O8jzzNfrJDVq/mA7qHjrljgZvzN0GGI0ehJbf
So+02BSthgThxEHAUzkquFDkVN7jEJVdUM7dIRRt4+8Fd4WK+TlaYCnnE2yfkEpy
axivK1aDJJ5HbvhOF+DsUZ0ur1JCxEAPG4xSnwIDAQABAoIBAQCwB27qXB0KkAaf
STusTjhYoYA7YaSmezwJTIX9X9T/PMzrUAYAMCO2KL5KRFLSxFHtWtpNTHxYYIwm
Bs8w7oJgaQOo0xKMgpRpYpfAHbqLYXOXX6m2FFA/RfBuKStLJxWlhiH2IgS0BzzG
omQgirhP1W/Nqu8nuWvp7bQYI0nbng6eG+dq75tn6XEnImFBv1ZP6RcIjazc7dHw
5E8hb1LvfJbccyQ+VLztziVP0kUTVACarrQfd+1CrC20jBZnhc/YlElFBnI2JpRY
7q5eVU/pmyhnF/ZAxq/he6dGeFd1hTJ3y3VT8fO51lm9wjkdYhkFbMKzQaSmNPOI
qesNqpzBAoGBAOkEg2Hhe3DwCiMVGsLCnTCJ+VkDh05loecv7VG94kVely1g0ROs
G3SGxvaR3L2R0rAC3ceyBr5ubO3QmBrB7NGEHndpkM+3qtt9WdsxWviXLVp1twBm
gMBPTlkMPWV9d5y/SZNIkRMCr464Z7RLMuLNHO+lEEQ0ztqIToy6rBdbAoGBAMsw
51skdOlm5qQcH6ceEk1VN8eQmYYOfLsP3sAUMNvPy8lFz639RAEW9l/LCrRC/TK5
FSDcvuNTdEPThooOVNZBpGUgZB43HyuYV4z4VVUP8p/639+qn+zw2xxfpZhZELjj
dtHwO3imjwmdtZP2USFzyIR4yZ/yrRC19jjVedkNAoGAfC0gis/rxaLV9B4yFao6
tHxCujIMMDYvEpHS6aXEaG1hKRiYMuCb/Pw6GXpf5VJJsezFHb98oo0cVZu9Az1n
I7xBtCc4uclKLw/dC9eAgEuoKrXioT7+y/03ZnMEYQp87LZv0iJw1W2v+uHAui78
3iqqifcv9PkjZwgOvCZawVMCgYAsDblLcHcMl6vPzu0p7YIoVB6Y3Qf8Ia33XLR9
zqLdNYtIYyNo5K1W0yStljcG6DM/SROEoXedj914SyczTXIlVewPpNswFeFjMU9i
GAFgROnkt57MPpEX7QyEdVRQ2Jagj2iWkdBDE1GV0ySoJNJoP1MtLYcBb7sIEXuF
zPrzDQKBgQCD08nt61sHiiKj6XGjqumPWEz6A/HJaXh17Sc7CE/33YmwaJNofZfI
7nRp567TGyz+gH+OZJ2/Mz3tMYxelpJsLIaZvoC9h1Zassiyf0cQ+xYB9GseqxLh
RE7OsVZKY8kdsg7WEOHXCQ6JMj/Y4JIq0guKP0m8/8oiN7lr13u4pQ==
-----END RSA PRIVATE KEY-----

# 8 - Criar a Service Connection no AzDevOps - SSH

# 9 - Adicionar a task do Ansible

# 10 - Instalar o pacote - fatal: [localhost]: FAILED! => {"changed": false, "msg": "Failed to import the required Python library (msrestazure) on ansible-vm-***'
sudo pip install msrestazure

sudo pip install "azure==2.0.0rc5"