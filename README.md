# Attelas

A simple prototype of a chatbot api that can assist with accounting-related tasks. 
### Local Machine
#### 1.Setup database
Create a postgresql instance, create database named `attelas` then run the `db.sql` script.
#### 2. Set up OpenAI API Key
Set openai api key in system env named `OPENAI_API_KEY`.
#### 3. Run the project
you can run with IDE such as Visual Studio or Rider, or run with dotnet CLI with in solution root path.
```bash
dotnet build 
dotnet run --project Attelas.WebApi
```

### Docker
1. update `docker-compose.yml` with your OpenAI API Key
2. run with docker compose

```bash
docker-compose up -d
```

## Self test result
### case 1
```bash
curl -X 'POST' \
  'http://localhost:5114/api/chat/completions' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "text": "Can you provide the status of invoice INV-1020?"
}'
```
```json
{
  "content": "The status of invoice INV-1020 is \"Pending\".",
  "role": "Assistant"
}
```
### case 2
```bash
curl -X 'POST' \
  'http://localhost:5114/api/chat/completions' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "text": "Thanks for sending over the invoice, have a great weekend"
}'
```
```json
{
  "content": "You're welcome! If you need any help with the invoice or any other accounting-related task, feel free to ask. Have a fantastic weekend!",
  "role": "Assistant"
}
```
### case 3
```bash
curl -X 'POST' \
  'http://localhost:5114/api/chat/completions' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "text": "Do we have any invoices due for Acme Corp"
}'
```
```json
{
  "content": "Yes, we have two pending invoices due for Acme Corp. Here are the details:\n\n1. Invoice Number: INV-1001\n   Due Date: September 30, 2023\n\n2. Invoice Number: INV-1020\n   Due Date: September 30, 2023\n\nIf you need more information or assistance with these invoices, feel free to let me know!",
  "role": "Assistant"
}
```
### case 4
```bash
curl -X 'POST' \
  'http://localhost:5114/api/chat/completions' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "text": "What'\''s the current status of INV-1003? I can'\''t find it in the system."
}'
```
```json
{
  "content": "The current status of invoice INV-1003 is \"Overdue\".",
  "role": "Assistant"
}
```

### case 5
```bash
curl -X 'POST' \
  'http://localhost:5114/api/chat/completions' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "text": "Could you check if INV-1020 has been processed?"
}'
```
```json
{
  "content": "Invoice INV-1020 with the status \"Pending\" has not been processed yet. It is still pending.",
  "role": "Assistant"
}
```
### case 6
```bash
curl -X 'POST' \
  'http://localhost:5114/api/chat/completions' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "text": "Could you please remind me address of Acme Corp and submit a new invoice for them please, thanks"
}'
```
```json
{
  "content": "Sure! The address of Acme Corp is 123 Main Street, Anytown, USA. Please provide me with the details for the new invoice you would like to submit to Acme Corp, including the invoice number, date, amount, and any other relevant information.",
  "role": "Assistant"
}
```
## Technical Design

My solution built on top of the following technologies:
- ASP.NET Core
- OpenAI SDK
- Dapper (An easy to use Object-Relational Mapping toolkit)
- Postgresql (Database)
- Docker (Containerization)

### Architecture
The Clean Architecture is used to structure the project. The project is divided into the following layers:
- **Domain**: Contains the entities, interfaces, and business logic.
- **Application**: Contains the use cases and application services.
- **Infrastructure**: Contains the implementation of the interfaces defined in the Domain layer.
- **WebApi**: Contains the controllers and the API configuration.



## Known Issues
Since this solution is a prototype within several **HOURS**, it has some known issues:
1. Intent classification and slot filling with LLM(OpenAI in this project) is not working as expected, Prompts need to be repeatedly tested. `Joint-BERT` or `Multi-Turn Conversation`  might be a possible solution, but it is not in the scope of this project.
2. Authentication/Authorization is not implemented. 
3. DI lifecycle was not checked.
4. Error handling is very simple.
5. No unit tests.
