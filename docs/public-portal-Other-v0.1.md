# ArsX Public Portal Other Files v0.1

## Code Overview

### styles.css
```css
:root{
  --bg:#f6f7f9; --ink:#253045; --muted:#5a6475; --card:#ffffff;
  --accent:#2b6cb0; --accent-ink:#ffffff; --wrap:1120px;
  --radius:14px; --pad:22px; --shadow:0 10px 30px rgba(0,0,0,.06);
  font-family: Inter, system-ui, -apple-system, "Segoe UI", Roboto, "Helvetica Neue", Arial, "Noto Sans";
}
*{box-sizing:border-box}
html,body{margin:0; padding:0; color:var(--ink); background:var(--bg); line-height:1.6}
.wrap{max-width:var(--wrap); margin:0 auto; padding:22px}
a{color:var(--accent); text-decoration:none}
a:hover{text-decoration:underline}

/* Header / Nav */
.site-header{background:#10131a; color:#d9e6ff; padding:16px 0; position:sticky; top:0; z-index:10}
.header-grid{display:flex; gap:16px; align-items:center; justify-content:space-between}
.brand h1{margin:0; font-weight:800; letter-spacing:.5px}
.brand .thin{font-weight:400; color:#9fb4d6}
.tagline{margin:4px 0 0; color:#9fb4d6; font-size:.95rem}
.nav a{color:#dbe9ff; margin-left:16px; font-weight:700; padding:6px 8px; border-radius:8px}
.nav a.active{background:#1c2638}
.nav a:hover{opacity:.9}

/* Panels & cards */
.panel{background:var(--card); border-radius:var(--radius); padding:var(--pad); margin:18px 0; box-shadow:var(--shadow)}
.hero{background:linear-gradient(180deg,#ffffff, #f1f5ff)}
.grid{display:grid; grid-template-columns:repeat(3,1fr); gap:16px}
.card{background:var(--card); border-radius:12px; padding:18px; box-shadow:var(--shadow)}
.card h3{margin-top:0}
.card .meta{color:var(--muted); margin:.2rem 0 .6rem}
.card-body{display:block}

/* Buttons */
.btn{display:inline-block; padding:10px 14px; background:var(--accent); color:var(--accent-ink);
     border-radius:10px; font-weight:700; letter-spacing:.2px; box-shadow:0 6px 18px rgba(43,108,176,.25)}
.btn:hover{filter:brightness(.95)}
.btn.ghost{background:transparent; color:var(--accent); border:2px solid var(--accent); box-shadow:none}
.btn-row,.cta-row{display:flex; gap:10px; flex-wrap:wrap}

/* Lists */
.bullets{margin:.2rem 0 0 1rem; color:var(--muted)}

/* Breadcrumb */
.breadcrumb{font-size:.9rem; color:#7a8596; margin-top:6px; margin-bottom:6px}
.breadcrumb a{color:#7a8596}
.breadcrumb a:hover{text-decoration:underline}

/* Footer */
.site-footer{padding:26px 0; color:#7a8596; text-align:center}

/* Responsive */
@media (max-width: 960px){
  .grid{grid-template-columns:1fr}
  .nav{display:flex; gap:14px; flex-wrap:wrap; justify-content:flex-end}
}

```

### README.md
```markdown
# arsx-co-uk.github.io
arsX Co-UK 
Human & AI Co-Creation Initiative. Publishing and research by Thomas Willis (arsX).

# arsX Co-UK 
Public Site

This repository hosts the GitHub Pages site for **arsX Co-UK**.

- Live: https://arsx-co-uk.github.io/
- License: [CC BY 4.0](LICENSE)

### Downloads
Drop public files into `/downloads/` (EPUB/PDF) or attach them to a GitHub Release and link from the site.

```

### index.html
```html
<!doctype html>
<html lang="en-GB">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width,initial-scale=1" />
  <title>arsX Co-UK 
Human & AI Co-Creation Group</title>
  <meta name="description" content="arsX Co-UK is the parent organisation for Orbital Forge (publishing), Cyber Knights (studio), and Fractured Sol (simulation)."/>
  <link rel="stylesheet" href="styles.css" />
  <meta property="og:title" content="arsX Co-UK 
Human & AI Co-Creation Group"/>
  <meta property="og:description" content="Parent hub for Orbital Forge publishing and arsX projects."/>
  <meta property="og:url" content="https://arsx-co-uk.github.io/"/>
  <meta property="og:type" content="website"/>
  <meta property="og:image" content="assets/cover-card.png"/>
  <meta name="twitter:card" content="summary_large_image"/>
</head>
<body>
  <header class="site-header">
    <div class="wrap header-grid">
      <div class="brand">
        <h1>arsX <span class="thin">Co-UK</span></h1>
        <p class="tagline">Human & AI Co-Creation Group</p>
      </div>
      <nav class="nav">
        <a class="active" href="index.html">Home</a>
        <a href="forge.html">Orbital Forge</a>
        <a href="#studios">Studios</a>
        <a href="#research">Research</a>
        <a href="#contact">Contact</a>
      </nav>
    </div>
  </header>

  <main class="wrap">
    <!-- Hero -->
    <section class="panel hero">
      <h2>We design systems. We publish clarity.</h2>
      <p>arsX Co-UK coordinates divisions across publishing, game studios, and research. This hub is the canonical source for releases and updates.</p>
      <div class="cta-row">
        <a class="btn" href="forge.html">Enter Orbital Forge (Publishing)</a>
        <a class="btn ghost" href="https://github.com/arsx-co-uk" target="_blank" rel="noopener">All repositories</a>
      </div>
    </section>

    <!-- Divisions -->
    <section id="divisions" class="panel">
      <h2>Divisions</h2>
      <div class="grid">
        <article class="card">
          <h3>Orbital Forge</h3>
          <p><strong>Publishing imprint.</strong> Manifestos, essays, rulebooks, technical docs. Dyslexia-friendly formats.</p>
          <p><a class="link" href="forge.html">Go to publishing 
</a></p>
        </article>

        <article id="studios" class="card">
          <h3>Cyber Knights</h3>
          <p>Studio: retro-industrial futurism, UK-centric civic resilience skirmish (tabletop + digital).</p>
          <p><a class="link" href="https://github.com/arsx-co-uk" target="_blank" rel="noopener">Index (incoming) 
</a></p>
        </article>

        <article class="card">
          <h3>Fractured Sol</h3>
          <p>Simulation division: hard-SF worldbuilding, comms architecture, logistics, factions.</p>
          <p><a class="link" href="https://github.com/ThomasWillis4477/FracturedSol" target="_blank" rel="noopener">Repository 
</a></p>
        </article>
      </div>
    </section>

    <!-- Research -->
    <section id="research" class="panel">
      <h2>Research & Initiatives</h2>
      <ul class="bullets">
        <li>Accessibility & typography for dyslexic readers</li>
        <li>Human
AI co-authoring protocols and audit trails</li>
        <li>Open distribution pipelines (EPUB 3, PDF, archival mirrors)</li>
      </ul>
    </section>

    <!-- Contact -->
    <section id="contact" class="panel">
      <h2>Contact</h2>
      <p>Email: <a href="mailto:thomas.willis4477@yahoo.co.uk">thomas.willis4477@yahoo.co.uk</a></p>
      <p>GitHub Org: <a href="https://github.com/arsx-co-uk" target="_blank" rel="noopener">github.com/arsx-co-uk</a></p>
    </section>
  </main>

  <footer class="site-footer">
    <div class="wrap">
      <small>
 arsX Co-UK 
Thomas Willis. Content under <a href="LICENSE">CC BY 4.0</a> unless stated.</small>
    </div>
  </footer>
  <script>document.getElementById('year').textContent=new Date().getFullYear();</script>
</body>
</html>

```

### forge.html
```html
<!doctype html>
<html lang="en-GB">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width,initial-scale=1" />
  <title>Orbital Forge 
Publishing Division of arsX Co-UK</title>
  <meta name="description" content="Orbital Forge is the publishing imprint of arsX Co-UK. Dyslexia-friendly releases in EPUB/PDF with public mirrors." />
  <link rel="stylesheet" href="styles.css" />
  <meta property="og:title" content="Orbital Forge 
Publishing Division"/>
  <meta property="og:description" content="Dyslexia-friendly releases, manifestos, and rulebooks."/>
  <meta property="og:type" content="website"/>
  <meta property="og:url" content="https://arsx-co-uk.github.io/forge.html"/>
  <meta property="og:image" content="assets/cover-card.png"/>
  <meta name="twitter:card" content="summary_large_image"/>
</head>
<body>
  <header class="site-header">
    <div class="wrap header-grid">
      <div class="brand">
        <h1>Orbital Forge</h1>
        <p class="tagline">Publishing Division of arsX Co-UK</p>
      </div>
      <nav class="nav">
        <a href="index.html">Home</a>
        <a class="active" href="forge.html">Orbital Forge</a>
        <a href="index.html#studios">Studios</a>
        <a href="index.html#research">Research</a>
        <a href="index.html#contact">Contact</a>
      </nav>
    </div>
  </header>

  <main class="wrap">
    <div class="breadcrumb"><a href="index.html">arsX Co-UK</a> 
Orbital Forge</div>

    <section class="panel hero">
      <h2>Publishing for comprehension, not conformity.</h2>
      <p>Orbital Forge is the imprint for all arsX publications. Our mandate: structure first, friction last 
 every release ships in accessible formats with open mirrors.</p>
    </section>

    <!-- Featured Title -->
    <section class="panel">
      <h2>Featured Release</h2>
      <article class="card">
        <div class="card-body">
          <h3>The Dyslexic Reformation</h3>
          <p class="meta">Author: <strong>Thomas Willis</strong> (arsX Initiative)</p>
          <p>A human
AI manifesto on dyslexic cognition, reading architecture, and public accessibility.</p>
          <div class="btn-row">
            <a class="btn" href="downloads/The-Dyslexic-Reformation.epub" download>Download EPUB</a>
            <a class="btn" href="downloads/The-Dyslexic-Reformation.pdf" download>Download PDF</a>
            <a class="btn ghost" href="https://www.wattpad.com/user/CmdWillis" target="_blank" rel="noopener">Wattpad</a>
          </div>
        </div>
      </article>
    </section>

    <!-- Roadmap / Imprint Notes -->
    <section class="panel">
      <h2>Imprint Notes</h2>
      <ul class="bullets">
        <li>Standard formats: EPUB 3 (reflow), PDF (print), with accessible typography.</li>
        <li>Distribution: GitHub Releases + Internet Archive mirrors; select retailers as needed.</li>
        <li>Licensing: <strong>CC BY 4.0</strong> unless otherwise stated.</li>
      </ul>
    </section>
  </main>

  <footer class="site-footer">
    <div class="wrap">
      <small>
 arsX Co-UK 
Orbital Forge. Content under <a href="LICENSE">CC BY 4.0</a> unless stated.</small>
    </div>
  </footer>
  <script>document.getElementById('year').textContent=new Date().getFullYear();</script>
</body>
</html>

```