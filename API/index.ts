// Imports
import * as express from "express";
import { Request, Response } from "express";
import { uptime } from "process";
import { rateLimit } from 'express-rate-limit';
import * as fs from "fs";

const app: express.Express = express.default();

app.use(express.static("public"));

const limiter = rateLimit({
    windowMs: 60 * 1000, // 1 minute
    limit: 1200,
    standardHeaders: 'draft-7',
    legacyHeaders: false,
    message: async (req: Request, res: Response) => {
        res.jsonp({ success: false, error: "RATELIMIT_EXCEEDED", message: "Ratelimit exceeded" });
    }
});

app.use(limiter);

if(!fs.existsSync("config.json")) {
    throw "No config file found";
}

const config = require(__dirname + "/config.json");
// Imports
import { generateRandomString, uptimeToHuman } from "./utils";

// API routes
app.get("/", (req: Request, res: Response) => {
    res.jsonp({
        status: "online",
        version : "1.0.0",
        uptime : uptime(),
        uptime_human: uptimeToHuman(uptime()),
        time: new Date(),
        rate_limits: {
            requests_per_minute: 1200,
            requests_per_second: 20,
            current_usage: (req as any).rateLimit.used
        },
        ip: req.ip,
        ips: req.ips,
        success: true
    });
});

app.get("/scanning/", async (req: Request, res: Response) => {
    const response = await fetch("https://raw.githubusercontent.com/MrBisquit/DevEnv/refs/heads/master/scanning.json");
    if(response.status == 200) {
        return res.jsonp({ ...(await response.json()), success: true });
    } else {
        return res.jsonp({
            message: "Did not receive status 200 from GitHub",
            success: false
        });
    }
});

app.get("/ui/scanning/", (req: Request, res: Response) => {
    return res.redirect("/ui/scanning.html");
});

// Listening
app.listen(config.port);