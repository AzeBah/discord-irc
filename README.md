# discord-irc
It's a custom irc discord client with self-bot functionalities
We currently at version 0.2 & I will be promoting this discord client once we reach it's first version.


Features -

- Working login system
- Working retrieve channel messages
- Working sending message to the discord channel
- Keep the 50 last messages in the memory (less ram usage :p)
- Self-Bot commands like "/delete 1" 
- Log with a token (user and/or bot token) - use token.txt

# Commands
- /delete 50 - this is a command to delete a specific amount of messages in the channel (50 in this case)
- /quit  - close app (token.txt is not erased)
- /logout - log out of the current account & delete the token from token.txt (if any)
- /join channelidhere - join a specific channel

# To-Do-List
- /dm username#id messageHere - command to send someone a specific message
- /notifications - get a list of unread channels/dm's
- Have an user presence(online/idle/dnd/offline) and be able to switch from one to another - requires websocket
- Use websocket connection instead of spamming http requests (less bandwidth usage)
- Write my own websocket implementation

# How-To-Use
1) Download this folder - https://github.com/AzeBah/discord-irc/releases/tag/0.2 - We update the release build once a week
2) Run Discord.exe
3) Use your account and feel free to modify the source code  
**if you want to use a token to log in (user or bot), make a file named token.txt in the same folder as Discord.exe**

Log in 
![login](https://i.imgur.com/tRfWruo.png)


Watch a specific channel id for messages
![WatchChannel](https://i.imgur.com/D2W9KSn.png)

Send Message & intercept them<br/>
![SendMessage](https://i.imgur.com/Kxk0Yh5.gif)
