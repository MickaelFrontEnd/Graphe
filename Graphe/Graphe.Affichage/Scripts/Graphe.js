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
                creerArcVis(a.from,a.to);
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
    id++;
}

function creerArcVis(org,arv) {
    edges.add({
        from: org,
        to: arv
    });
    edges.update(edgesArray);
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

$(document).ready(function () {
    initVis();

    $('#creer-noeud-btn').click(function(e) {
        e.preventDefault();
        var nom = $('#nom-noeud').val();
        creerNoeudAPI(nom);
        creerNoeudVis(nom);
    });
});

