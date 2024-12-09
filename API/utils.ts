const generateRandomString = (length: number): string => {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    let result = '';
    const charactersLength = characters.length;
    for (let i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
}

const uptimeToHuman = (uptime: number): string => {
    // ChatGPT because it's too much of a pain to do manually
    const years = Math.floor(uptime / (60 * 60 * 24 * 365.25)); // Average year length
	uptime -= years * (60 * 60 * 24 * 365.25);

	const months = Math.floor(uptime / (60 * 60 * 24 * 30.44)); // Average month length
	uptime -= months * (60 * 60 * 24 * 30.44);

	const days = Math.floor(uptime / (60 * 60 * 24));
	uptime -= days * (60 * 60 * 24);

	const hours = Math.floor(uptime / (60 * 60));
	uptime -= hours * (60 * 60);

	const minutes = Math.floor(uptime / 60);
	uptime -= minutes * 60;

	const seconds = Math.floor(uptime);
	uptime -= seconds;

	const milliseconds = Math.floor(uptime * 1000); // Getting milliseconds from the decimal part

	// Constructing the string
	let timeString = '';
	if (years > 0) timeString += `${years} years `;
	if (months > 0) timeString += `${months} months `;
	if (days > 0) timeString += `${days} days `;
	if (hours > 0) timeString += `${hours} hours `;
	if (minutes > 0) timeString += `${minutes} minutes `;
	if (seconds > 0) timeString += `${seconds} seconds `;
	if (milliseconds > 0) timeString += `${milliseconds} milliseconds`;

	// Removing trailing space
	return timeString.trim();
}

export { generateRandomString, uptimeToHuman };