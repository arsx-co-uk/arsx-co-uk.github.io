// [ArsX:Phase1Patch]
window.__ARSX_API__ = {
    whoami: () => Promise.resolve({ user: "demo", role: "L3", status: "ok" }),
    projects: () => Promise.resolve([
        {
            name: "Orbital Forge",
            role: "Publishing Imprint",
            desc: "Manifestos and rulebooks in accessible formats."
        },
        {
            name: "Cyber Knights",
            role: "Studio",
            desc: "Retro-industrial futurism skirmish series."
        },
        {
            name: "Fractured Sol",
            role: "Simulation Division",
            desc: "Hard-SF worldbuilding and comms architecture."
        }
    ])
};