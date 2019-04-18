var URL = 'http://localhost:61374/';
var nodes;
var edges;
var nodesArray = [];
var edgesArray = [];
var id = 0;
var container;
var network;

function initVis() {
    initVisOptions(); 
    initVisEvent();
}

function initVisOptions() {
    container = document.getElementById('vis-container');
    nodes = new vis.DataSet(nodesArray);
    edges = new vis.DataSet(edgesArray);
    var data = {
        nodes: nodes,
        edges: edges
    }
    var options = {
        nodes: {
            shape: 'dot',
            size: 25,
            font: {
                size: 26
            },
            borderWidth: 2,
            shadow:true
        },
        edges: {
            width: 2,
            shadow:true,
            arrows: {
                to:     {enabled: false, scaleFactor:1, type:'arrow'},
                middle: {enabled: true, scaleFactor:1, type:'arrow'},
                from:   {enabled: false, scaleFactor:1, type:'arrow'}
            }
        },
        interaction: {
            multiselect: true
        },
        manipulation: {
            enabled: false,
            addEdge: function(a,b) {
                $('#ajouter-arc-modal').data('a',a.from);
                $('#ajouter-arc-modal').data('b',a.to);
                afficherAjouterArc();
            }
        }
    };
    network = new vis.Network(container, data, options);
}

function initVisEvent() {
    network.on('selectNode',function(e){
        var nodes = e.nodes;
        if(nodes.length == 2) {        
            network.addEdgeMode();
        }
    });
}

function creerNoeudVis(nom) {
    nodes.add({
        id: id,
        label: nom,
        group: 0
    });
    nodesArray.push({
        id: id,
        label: nom,
        group: 0
    })
    id++;
}

function creerArcVis(org,arv,capacite,cout) {
    edges.add({
        from: org,
        to: arv,
        label: '(' + capacite + ',' + cout + ')'
    });
    edgesArray.push({
        from: org,
        to: arv
    });
}

function creerNoeudAPI(nom) {
    $.post(
        URL + 'Home/AjouterNoeud',
        {
            nomNoeud: nom
        },
        function(result) {
            if(result.status === 'created') {
                $('#ajouter-noeud-modal').modal('hide');
                $('#nom-noeud').val('');
            }
        }   
    );
}

function creerArcAPI(a,b) {
    $.post(
        URL + 'Home/AjouterArc',
        {
            noeudA: nodesArray[a].label,
            noeudB: nodesArray[b].label,
            capacite: $('#capacite-noeud').val(),
            cout: $('#cout-noeud').val()
        },
        function(result) {
            if(result.status === 'created') {
                $('#ajouter-arc-modal').modal('hide');
                creerArcVis(a,b,$('#capacite-noeud').val(),$('#cout-noeud').val());
                $('#capacite-noeud').val('0');
                $('#cout-noeud').val('0');
            }
        }   
    );
}

function afficherAjouterArc() {
    $('#ajouter-arc-modal').modal('show');
}

$(document).ready(function () {
    initVis();

    $('#creer-noeud-btn').click(function(e) {
        e.preventDefault();
        var nom = $('#nom-noeud').val();
        creerNoeudAPI(nom);
        creerNoeudVis(nom);
    });

    $('#creer-arc-btn').click(function(e) {
        e.preventDefault();
        var a = $('#ajouter-arc-modal').data('a');
        var b = $('#ajouter-arc-modal').data('b');
        creerArcAPI(a,b);
    });
});

