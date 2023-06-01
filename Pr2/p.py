HostData = []
with open("HOSTS.txt", "r") as reader:
    for line in reader:
        line = line.strip()
        if len(line) == 0 or line[0] == '#':
            continue

        parts = line.split()
        if len(parts) < 2:
            continue

        HostData.append(parts[1])

LogData = []
with open("dns.log", "r") as reader:
    for line in reader:
        line = line.strip()
        if len(line) == 0 or line[0] == '#':
            continue

        parts = line.split()
        if len(parts) >= 10:
            LogData.append(parts[9])

result = 0
for logData in LogData:
    if logData in HostData:
        result += 1

print("Количество совпадений =", result)
